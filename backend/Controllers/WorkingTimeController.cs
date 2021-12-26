using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Context;
using Backend.Dtos;
using Backend.Entities;
using Backend.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    public class WorkingTimeController : Controller
    {
        private readonly HospitalContext _context;
        private const int visitLength = 20;
        public WorkingTimeController(HospitalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GetWorkingTimeDto>> Get()
        {
            var list = from w in _context.WorkingTimes
                       join c in _context.Clinics on w.clinic.id equals c.id
                       join m in _context.Medics on w.medic.id equals m.id
                       select new
                       {
                           id = w.id,
                           startDate = w.startDate,
                           endDate = w.endDate,
                           clinic = c.AsGetEntityDto(),
                           medic = m.AsGetEntityDto()
                       };

            var res = list.Select(w => new GetWorkingTimeDto
            {
                id = w.id,
                clinic = w.clinic,
                endDate = w.endDate,
                startDate = w.startDate,
                medic = w.medic
            }).ToList();

            return res;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateWorkingTimeDto value)
        {
            if (value.endDate < value.startDate)
            {
                return StatusCode(400, "endDate can't be before startDate");
            }

            var clinic = _context.Clinics.FirstOrDefault(clinic => clinic.id == value.clinicId);
            if (clinic == null)
            {
                return StatusCode(400, "Wrong clinic id");
            }

            var medic = _context.Medics.FirstOrDefault(medic => medic.id == value.medicId);
            if (medic == null)
            {
                return StatusCode(400, "Wrong medic id");
            }

            var workingTime = value.AsWorkingTime(medic, clinic);
            _context.WorkingTimes.Add(workingTime);
            _context.SaveChanges();

            int numberOfVisits = (int)Math.Round((value.endDate - value.startDate).TotalMinutes / visitLength);

            var newVisits = Enumerable.Range(0, numberOfVisits).Select(time => new Visit
            {
                id = 0,
                description = null,
                patient = null,
                receptionist = null,
                startDate = value.startDate.AddMinutes(time * visitLength),
                workingTime = workingTime
            });

            foreach (var visit in newVisits)
            {
                _context.Visits.Add(visit);
            }
            _context.SaveChanges();

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateWorkingTimeDto value)
        {
            var clinic = _context.Clinics.FirstOrDefault(clinic => clinic.id == value.clinicId);
            if (clinic == null)
            {
                return StatusCode(400, "Wrong clinic id");
            }

            var medic = _context.Medics.FirstOrDefault(medic => medic.id == value.medicId);
            if (medic == null)
            {
                return StatusCode(400, "Wrong medic id");
            }

            var existingWorkingTime = await _context.WorkingTimes.FindAsync(id);
            var isWorkingTimePresent = !(existingWorkingTime == null);
            if (!isWorkingTimePresent)
            {
                return StatusCode(400, "WorkingTime not found");
            }

            existingWorkingTime.clinic = clinic;
            existingWorkingTime.medic = medic;
            existingWorkingTime.endDate = value.endDate;
            existingWorkingTime.startDate = value.startDate;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!isWorkingTimePresent)
            {
                return StatusCode(503, "Failed to save");
            }

            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var existingWorkingTime = await _context.WorkingTimes.FindAsync(id);

            if (existingWorkingTime == null)
            {
                return NotFound();
            }

            _context.WorkingTimes.Remove(existingWorkingTime);
            await _context.SaveChangesAsync();

            return StatusCode(201);
        }
    }
}