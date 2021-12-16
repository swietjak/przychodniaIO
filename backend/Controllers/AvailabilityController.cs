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
 
    }
}