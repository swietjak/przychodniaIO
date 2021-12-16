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
    public class PatientController : Controller
    {
        private readonly HospitalContext _context;

        public PatientController(HospitalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<GetPatientDto> Get()
        {
            return _context.Patients.Select(patient => patient.AsGetPatientDto()).ToList();
        }

        [HttpGet("{id}")]
        public GetPatientDto Get(int id)
        {
            return _context.Patients.FirstOrDefault(x => x.id == id).AsGetPatientDto();
        }

        [HttpPost]
        public IActionResult CreatePatient([FromBody] CreatePatientDto value) 
        {
          _context.Patients.Add(value.AsPatient());

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