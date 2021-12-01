using System.Collections.Generic;
using System.Linq;
using Backend.Context;
using Backend.Entities;
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
        public IEnumerable<Specialization> Get()
        {
            return _context.Specializations.ToList();
        }

        [HttpGet("{id}")]
        public Specialization Get(int id)
        {
            return _context.Specializations.FirstOrDefault(x => x.id == id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Specialization value)
        {
            _context.Specializations.Add(value);
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