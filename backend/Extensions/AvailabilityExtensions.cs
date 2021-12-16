using System.Collections.Generic;
using Backend.Dtos;
using Backend.Entities;
using System.Linq;

namespace Backend.Extensions
{
    public static class AvailabilityExtensions
    {
        public static GetAvailabilityDto AsGetAvailabilityDto(this Availability item, int medicId)
        {
            return new GetAvailabilityDto
            {
                id = item.id,
                startDate = item.startDate,
                endDate = item.endDate,
                medicId = medicId
            };
        }

        public static Availability AsAvailability(this CreateAvailabilityDto item, Medic medic)
        {
            return new Availability
            {
                id = 0,
                endDate = item.endDate,
                medic = medic,
                startDate = item.startDate
            };
        }
    }
}