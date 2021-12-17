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
    public class AvailabilityController : Controller
    {
        private readonly HospitalContext _context;

        public AvailabilityController(HospitalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GetAvailabilityDto>> Get()
        {
            var list = _context.Availabilities.Join(_context.Medics, availablity 
            => availablity.medic.id, medic => medic.id, (availability, medic)=>availability.AsGetAvailabilityDto(medic.AsGetEntityDto())
            ).ToList();
            return list;
        }


        // [HttpGet("{id}")]
        // public GetAvailabilityDto Get(int id)
        // {
        //     return _context.Availabilities.FirstOrDefault(x => x.id == id).AsGetAvailabilityDto();
        // }

        [HttpPost]
        public IActionResult CreateAvailbility([FromBody] CreateAvailabilityDto value)
        {
            var medicsList = _context.Medics.FirstOrDefault(_medicId => _medicId.id == value.medicId);

            _context.Availabilities.Add(value.AsAvailability(medicsList));

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
        public async Task<ActionResult> UpdateAvailability(int id, UpdateAvailabilityDto entityDto) 
        {

            var existingAvailability = await _context.Availabilities.FindAsync(id);
            var medicsList = _context.Medics.FirstOrDefault(x => x.id == entityDto.medicId);
            var isAvailabilityPresent = existingAvailability == null;
            if(isAvailabilityPresent) 
            {
                return NotFound();
            }

            existingAvailability.startDate = entityDto.startDate;
            existingAvailability.endDate = entityDto.endDate;
            existingAvailability.medic = medicsList;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!isAvailabilityPresent)
            {
                return NotFound();
            }

            return StatusCode(201);  
        }
 
       [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAvailability(int id)
        {
            var existingAvailability = await _context.Availabilities.FindAsync(id);
            var isAvailabilityPresent = existingAvailability == null;
            if(isAvailabilityPresent) 
            {
                return NotFound();
            }

            _context.Availabilities.Remove(existingAvailability);
            await _context.SaveChangesAsync();

            return StatusCode(201);
        }

    }
}