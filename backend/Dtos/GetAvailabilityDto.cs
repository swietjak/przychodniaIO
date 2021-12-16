using System;
using System.Collections.Generic;

namespace Backend.Dtos
{
    public record GetAvailabilityDto
    {
        public int id { get; init; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public  GetEntityDto medic { get; set; }
    }
}