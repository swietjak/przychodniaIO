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
    }
}