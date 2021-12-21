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
    public class ManagerController : Controller
    {
        private readonly HospitalContext _context;

        public ManagerController(HospitalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GetUserDto>> Get()
        {
            var list = _context.Managers.Select(manager => manager.AsGetUserDto()).ToList();
            return list;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateUserDto value)
        {
            _context.Managers.Add(value.AsManager());
            _context.SaveChanges();

            return StatusCode(200, "OK");
        }
    }
}