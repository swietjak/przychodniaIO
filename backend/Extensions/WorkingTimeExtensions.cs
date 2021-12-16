using System.Collections.Generic;
using Backend.Dtos;
using Backend.Entities;
using System.Linq;

namespace Backend.Extensions
{
    public static class WorkingTimeExtensions
    {
        public static WorkingTime AsWorkingTime(this CreateWorkingTimeDto item, Medic medic, Clinic clinic)
        {
            return new WorkingTime
            {
                clinic = clinic,
                medic = medic,
                endDate = item.endDate,
                startDate = item.startDate,
                id = 0
            };
        }
    }
}