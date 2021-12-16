using System.Collections.Generic;
using System.Linq;
using Backend.Context;
using Backend.Dtos;
using Backend.Extensions;
using Microsoft.AspNetCore.Mvc;

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
    }
}