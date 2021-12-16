using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Context;
using Backend.Dtos;
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

            var list = from v in _context.Visits
                       join p in _context.Patients on v.patient.id equals p.id
                       join w in _context.WorkingTimes on v.workingTime.id equals w.id
                       join r in _context.Receptionists on v.receptionist.id equals r.id
                       join m in _context.Medics on w.medic.id equals m.id
                       select new
                       {
                           id = v.id,
                           description = v.description,
                           startDate = v.startDate,
                           doctor = m.AsGetEntityDto(),
                           patient = p.AsGetEntityDto(),
                           receptionist = r.AsGetEntityDto()
                       };

            var res = list.Select(elem => new GetVisitDto
            {
                id = elem.id,
                description = elem.description,
                startDate = elem.startDate,
                doctor = elem.doctor,
                patient = elem.patient,
                receptionist = elem.receptionist
            }).ToList();
            return res;
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
        public async Task<ActionResult> UpdateVisit(int id, UpdateVisitDto entityDto){

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
        public async Task<ActionResult> DeleteVisit(int id){
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