using System.Collections.Generic;
using System.Linq;
using Backend.Context;
using Backend.Dtos;
using Backend.Entities;
using Backend.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    public class MedicController : Controller
    {
        private readonly HospitalContext _context;

        public MedicController(HospitalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GetMedicDto>> Get()
        {
            var list = _context.Medics.Select(medic => medic.AsGetMedicDto()).ToList();
            return list;
        }

        [HttpPost]
        public IActionResult CreateMedic([FromBody] CreateMedicDto value)
        {
            var specializationsList = _context.Specializations.Where(specialization => value.specialization_ids.Any(id => id == specialization.id)).ToList();
            var clinicsList = _context.Clinics.Where(clinic => value.clinic_ids.Any(id => id == clinic.id)).ToList();

            _context.Medics.Add(value.AsMedic(specializationsList, clinicsList));
            

            try 
            {
                _context.SaveChanges();
                return StatusCode(201, value);
             }
             catch
            {
                return StatusCode(400, "Failed");
            }
        }
    }
}