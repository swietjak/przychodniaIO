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
    public class ReceptionistController : Controller
    {
        private readonly HospitalContext _context;

        public ReceptionistController(HospitalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GetReceptionistDto>> Get()
        {
            var list = _context.Receptionists
            .Join(_context.Clinics, receptionist => receptionist.clinic.id, clinic => clinic.id, (receptionist, clinic) => receptionist.AsGetReceptionistDto(clinic))
            .ToList();
            return list;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateReceptionistDto value)
        {
            var clinic = _context.Clinics.FirstOrDefault(_clinic => _clinic.id == value.clinicId);
            if (clinic == null)
                return StatusCode(400, "No such clinic");
            _context.Receptionists.Add(value.AsReceptionist(clinic));
            _context.SaveChanges();

            return StatusCode(200, "OK");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] CreateReceptionistDto value)
        {
            var clinic = _context.Clinics.FirstOrDefault(_clinic => _clinic.id == value.clinicId);
            if (clinic == null)
                return StatusCode(400, "No such clinic");

            var existingReceptionist = await _context.Receptionists.FindAsync(id);
            var isReceptionistPresent = !(existingReceptionist == null);
            if (!isReceptionistPresent)
            {
                return StatusCode(400, "No such receptionist");
            }

            existingReceptionist.address = value.address;
            existingReceptionist.mail = value.mail;
            existingReceptionist.name = value.name;
            existingReceptionist.password = value.password;
            existingReceptionist.PESEL = value.PESEL;
            existingReceptionist.phone = value.phone;
            existingReceptionist.clinic = clinic;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!isReceptionistPresent)
            {
                return StatusCode(503, "Failed to save");
            }

            return StatusCode(200, "OK");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var existingReceptionist = await _context.Receptionists.FindAsync(id);

            if (existingReceptionist == null)
            {
                return NotFound();
            }

            _context.Receptionists.Remove(existingReceptionist);
            await _context.SaveChangesAsync();

            return StatusCode(201);
        }
    }
}