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
    public class LoginController : Controller
    {
        private readonly HospitalContext _context;

        public LoginController(HospitalContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginDto value)
        {
            var medic = _context.Medics.FirstOrDefault(medic => medic.mail.Equals(value.email));
            if (medic != null)
            {
                if (!medic.password.Equals(value.password))
                {
                    return StatusCode(400, "Bad password");
                }
                return StatusCode(201, "MEDIC " + medic.medicRole.ToString("G"));
            }

            var patient = _context.Patients.FirstOrDefault(patient => patient.mail.Equals(value.email));
            if (patient != null)
            {
                if (!patient.password.Equals(value.password))
                {
                    return StatusCode(400, "Bad password");
                }
                return StatusCode(201, "PATIENT");
            }

            var manager = _context.Managers.FirstOrDefault(manager => manager.mail.Equals(value.email));
            if (manager != null)
            {
                if (!manager.password.Equals(value.password))
                {
                    return StatusCode(400, "Bad password");
                }
                return StatusCode(201, "MANAGER");
            }

            var receptionist = _context.Receptionists.FirstOrDefault(receptionist => receptionist.mail.Equals(value.email));
            if (receptionist != null)
            {
                if (!receptionist.password.Equals(value.password))
                {
                    return StatusCode(400, "Bad password");
                }
                return StatusCode(201, "RECEPTIONIST");
            }

            return StatusCode(400, "Bad mail");
        }
    }
}