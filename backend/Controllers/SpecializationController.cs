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
    public class SpecializationController : Controller
    {
        private readonly HospitalContext _context;

        public SpecializationController(HospitalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<GetSpecializationDto> Get()
        {
            return _context.Specializations.Select(specialization => specialization.AsGetSpecializationDto()).ToList();
        }

        [HttpGet("{id}")]
        public GetSpecializationDto Get(int id)
        {
            return _context.Specializations.FirstOrDefault(x => x.id == id).AsGetSpecializationDto();
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateSpecializationDto value)
        {
            _context.Specializations.Add(value.AsSpecialization());
            try
            {
                _context.SaveChanges();
                return StatusCode(201, value);
            }
            catch
            {
                return StatusCode(400, "XDDD");
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSpecialization(int id, UpdateSpecializationDto entityDto){

            var existingSpecialization = await _context.Specializations.FindAsync(id);
            var isSpecializationPresent = existingSpecialization == null;
            if (isSpecializationPresent)
            {
                return NotFound();
            }

            existingSpecialization.name = entityDto.name;
            existingSpecialization.description = entityDto.description;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!isSpecializationPresent)
            {
                return NotFound();
            }

            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSpecialization(int id){
            var existingSpecialization = await _context.Specializations.FindAsync(id);
            var isSpecializationPresent = existingSpecialization == null;
            if (isSpecializationPresent)
            {
                return NotFound();
            }

            _context.Specializations.Remove(existingSpecialization);
            await _context.SaveChangesAsync();

            return StatusCode(201);

        }
    }
}