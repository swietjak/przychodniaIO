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

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatPatient(int id, UpdatePatientDto entityDto)
        {
            var existingPatient = await _context.Patients.FindAsync(id);
            var isPatientPresent = existingPatient == null;
            if(isPatientPresent)
            {
                return NotFound();
            }

            existingPatient.insuranceId = entityDto.insuranceId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!isPatientPresent)
            {
                return NotFound();
            }

            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePatient(int id)
        {
            var existingPatient = await _context.Patients.FindAsync(id);
            var isPatientPresent = existingPatient == null;
            if(isPatientPresent)
            {
                return NotFound();
            }

            _context.Patients.Remove(existingPatient);
            await _context.SaveChangesAsync();

            return StatusCode(201);
        }
    }
}