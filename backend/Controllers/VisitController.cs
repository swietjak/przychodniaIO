using System;
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
    public class GetPatientVisits
    {

    }
    [Route("api/[controller]")]
    public class VisitController : Controller
    {
        private readonly HospitalContext _context;

        public VisitController(HospitalContext context)
        {
            _context = context;
        }

        private bool ValidateVisit(Visit visit, int? clinicId, int? medicId)
        {
            if (clinicId == null && medicId == null) return true;

            if (clinicId == visit.workingTime.clinic.id) return true;

            if (medicId == visit.workingTime.medic.id) return true;

            return false;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GetVisitDto>> Get()
        {
            var list = _context.Visits
            .Include(visit => visit.patient)
            .Include(visit => visit.receptionist)
            .Include(visit => visit.workingTime)
            .Include(visit => visit.workingTime.clinic)
            .Include(visit => visit.workingTime.medic)
            .Select(visit => visit.AsGetVisitDto())
            .ToList();

            return list;
        }

        [HttpGet("{clinicId}")]
        public ActionResult<IEnumerable<GetVisitDto>> GetClinicEmptyVisits(int clinicId, DateTime day, int? medicId)
        {
            var list = _context.Visits
            .Include(visit => visit.patient)
            .Include(visit => visit.receptionist)
            .Include(visit => visit.workingTime)
            .Include(visit => visit.workingTime.clinic)
            .Include(visit => visit.workingTime.medic)
            .Where(visit => clinicId == visit.workingTime.clinic.id || medicId == visit.workingTime.medic.id || day.Date == visit.startDate.Date && visit.patient == null)
            .Select(visit => visit.AsGetVisitDto())
            .ToList();

            return list;
        }

        [HttpGet("{patientId}/patient-visits")]
        public ActionResult<IEnumerable<GetVisitDto>> GetPatientVisits(int patientId)
        {
            var list = _context.Visits
            .Include(visit => visit.patient)
            .Include(visit => visit.receptionist)
            .Include(visit => visit.workingTime)
            .Include(visit => visit.workingTime.clinic)
            .Include(visit => visit.workingTime.medic)
            .Where(visit => visit.patient.id == patientId)
            .Select(visit => visit.AsGetVisitDto())
            .ToList();

            return list;
        }

        [HttpPost]
        public IActionResult CreateVisit([FromBody] CreateVisitDto value)
        {
            try
            {
                var workingTime = _context.WorkingTimes.FirstOrDefault(_workingTime => _workingTime.id == value.workingTimeId);
                var patient = _context.Patients.FirstOrDefault(_patient => _patient.id == value.patientId);
                var receptionist = _context.Receptionists.FirstOrDefault(_receptionist => _receptionist.id == value.receptionistId);

                _context.Visits.Add(value.AsVisit(patient, receptionist, workingTime));
                _context.SaveChanges();

                return StatusCode(201, value);
            }
            catch (System.Exception)
            {
                return StatusCode(400, "Error");
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateVisit(int id, UpdateVisitDto entityDto)
        {

            var existingVisit = await _context.Visits.FindAsync(id);
            var workinTime = _context.WorkingTimes.FirstOrDefault(x => x.id == entityDto.workingTimeId);
            var isVisitPresent = existingVisit == null;
            if (isVisitPresent)
            {
                return NotFound();
            }

            existingVisit.startDate = entityDto.startDate;
            existingVisit.workingTime = workinTime;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!isVisitPresent)
            {
                return NotFound();
            }

            return StatusCode(201);
        }

        [HttpPut("{visitId}/book")]
        public async Task<ActionResult> BookVisit(int visitId, int patientId)
        {

            var existingVisit = await _context.Visits.FindAsync(visitId);
            var patient = await _context.Patients.FindAsync(patientId);
            var isVisitPresent = existingVisit == null;
            if (isVisitPresent || patient == null)
            {
                return NotFound();
            }
            existingVisit.patient = patient;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!isVisitPresent)
            {
                return NotFound();
            }

            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVisit(int id)
        {
            var existingVisit = await _context.Visits.FindAsync(id);
            var isVisitPresent = existingVisit == null;
            if (isVisitPresent)
            {
                return NotFound();
            }

            _context.Visits.Remove(existingVisit);
            await _context.SaveChangesAsync();

            return StatusCode(201);

        }
    }
}