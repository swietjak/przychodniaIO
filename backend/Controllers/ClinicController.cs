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
                var list = _context.Clinics.Join(_context.Specializations, clinic => clinic.specialization.id, specialization => specialization.id, (clinic, specialization) => clinic.AsGetClinicDto(specialization)
                ).ToList();
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

           
            try 
            {
                _context.SaveChanges();
                return StatusCode(201, clinic.id);
            }
          catch
            {
              return StatusCode(400, "Failed");
            }
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateClinic(int id, UpdateClinicDto entityDto){

            var existingClinic = await _context.Clinics.FindAsync(id);
            var specialization = _context.Specializations.FirstOrDefault(x => x.id == entityDto.specialization_id);
            var isClinicPresent = existingClinic == null;
            if (isClinicPresent)
            {
                return NotFound();
            }

            existingClinic.name = entityDto.name;
            existingClinic.address = entityDto.address;
            existingClinic.mail = entityDto.mail;
            existingClinic.phone = entityDto.phone;
            existingClinic.menager_id = entityDto.menager_id;
            existingClinic.specialization = specialization;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!isClinicPresent)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClinic(int id){
            var existingClinic = await _context.Clinics.FindAsync(id);
            var isClinicPresent = existingClinic == null;
            if (isClinicPresent)
            {
                return NotFound();
            }

            _context.Clinics.Remove(existingClinic);
            await _context.SaveChangesAsync();

            return StatusCode(201);

        }
    }
}