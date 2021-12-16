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
            _context.SaveChanges();

            return StatusCode(201, value);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMedic(int id, UpdateMedicDto value){

            var existingMedic = await _context.Medics.FindAsync(id);
            var specializationsList = _context.Specializations.Where(specialization => value.specialization_ids.Any(id => id == specialization.id)).ToList();
            var clinicsList = _context.Clinics.Where(clinic => value.clinic_ids.Any(id => id == clinic.id)).ToList();
            var isMedicPresent = existingMedic == null;
            if (isMedicPresent)
            {
                return NotFound();
            }

            existingMedic.medicRole = (MedicRole)System.Enum.Parse(typeof(MedicRole),value.role);
            existingMedic.specializations = specializationsList;
            existingMedic.clinics = clinicsList;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!isMedicPresent)
            {
                return NotFound();
            }

            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMedic(int id){
            var existingMedic = await _context.Medics.FindAsync(id);
            var isMedicPresent = existingMedic == null;
            if (isMedicPresent)
            {
                return NotFound();
            }

            _context.Medics.Remove(existingMedic);
            await _context.SaveChangesAsync();

            return StatusCode(201);
        }
    }
}