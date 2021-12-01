using System.Collections.Generic;
using System.Linq;
using Backend.Context;
using Backend.Dtos;
using Backend.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    public class ClinicController : Controller
    {
        private readonly HospitalContext _context;

        public ClinicController(HospitalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GetClinicDto>> Get()
        {
            try
            {
                System.Console.WriteLine(_context.Clinics.ToList());
                var list = _context.Clinics.Join(_context.Specializations, clinic => clinic.specialization.id, specialization => specialization.id, (clinic, specialization) => new GetClinicDto
                {
                    specialization = specialization.AsGetSpecializationDto(),
                    address = clinic.address,
                    id = clinic.id,
                    mail = clinic.mail,
                    menager_id = clinic.menager_id,
                    name = clinic.name,
                    phone = clinic.phone
                }).ToList();
                System.Console.WriteLine(list);

                return list;
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpGet("{id}")]
        public GetClinicDto Get(int id)
        {
            return _context.Clinics.FirstOrDefault(x => x.id == id).AsGetClinicDto();
        }

        [HttpPost]
        public IActionResult CreateClinic([FromBody] CreateClinicDto value)
        {
            var specialization = _context.Specializations.FirstOrDefault(x => x.id == value.specialization_id);
            if (specialization == null)
                return StatusCode(400, "Wrong specialization picked");

            Clinic clinic = value.AsClinic(specialization);
            _context.Clinics.Add(clinic);

            _context.SaveChanges();
            return StatusCode(201, clinic.id);
        }
    }
}