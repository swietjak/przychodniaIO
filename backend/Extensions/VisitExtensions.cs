using System.Collections.Generic;
using Backend.Dtos;
using Backend.Entities;
using System.Linq;

namespace Backend.Extensions
{
    public static class VisitExtensions
    {
        public static GetVisitDto AsGetVisitDto(this Visit item)
        {
            return new GetVisitDto
            {
                id = item.id,
                description = item.description,
                doctor = item.workingTime == null ? null : item.workingTime.medic.AsGetEntityDto(),
                patient = item.patient == null ? null : item.patient.AsGetEntityDto(),
                receptionist = item.receptionist == null ? null : item.receptionist.AsGetEntityDto(),
                startDate = item.startDate
            };
        }

        public static Visit AsVisit(this CreateVisitDto item, Patient patient, Receptionist receptionist, WorkingTime workingTime)
        {
            return new Visit
            {
                id = 0,
                description = item.description,
                patient = patient,
                receptionist = receptionist,
                startDate = item.startDate,
                workingTime = workingTime
            };
        }
    }
}