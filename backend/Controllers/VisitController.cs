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
    public class VisitController : Controller
    {
        private readonly HospitalContext _context;

        public VisitController(HospitalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GetVisitDto>> Get()
        {
            var list = _context.Visits
            .Include(visit => visit.patient)
            .Include(visit => visit.receptionist)
            .Include(visit => visit.workingTime)
            .Include(visit => visit.workingTime.clinic)
            .Include(visit => visit.workingTime.medic)
            .Select(visit => visit.AsGetVisitDto())
            .ToList();

            return list;
        }

        [HttpPost]
        public IActionResult CreateVisit([FromBody] CreateVisitDto value)
        {
            try
            {
                var workingTime = _context.WorkingTimes.FirstOrDefault(_workingTime => _workingTime.id == value.workingTimeId);
                var patient = _context.Patients.FirstOrDefault(_patient => _patient.id == value.patientId);
                var receptionist = _context.Receptionists.FirstOrDefault(_receptionist => _receptionist.id == value.receptionistId);

                _context.Visits.Add(value.AsVisit(patient, receptionist, workingTime));
                _context.SaveChanges();

                return StatusCode(201, value);
            }
            catch (System.Exception)
            {
                return StatusCode(400, "Error");
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateVisit(int id, UpdateVisitDto entityDto)
        {

            var existingVisit = await _context.Visits.FindAsync(id);
            var workinTime = _context.WorkingTimes.FirstOrDefault(x => x.id == entityDto.workingTimeId);
            var isVisitPresent = existingVisit == null;
            if (isVisitPresent)
            {
                return NotFound();
            }

            existingVisit.startDate = entityDto.startDate;
            existingVisit.workingTime = workinTime;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!isVisitPresent)
            {
                return NotFound();
            }

            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVisit(int id)
        {
            var existingVisit = await _context.Visits.FindAsync(id);
            var isVisitPresent = existingVisit == null;
            if (isVisitPresent)
            {
                return NotFound();
            }

            _context.Visits.Remove(existingVisit);
            await _context.SaveChangesAsync();

            return StatusCode(201);

        }
    }
}