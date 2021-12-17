using System;
using System.Collections.Generic;

namespace Backend.Dtos
{
    public record UpdateAvailabilityDto 
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public  int medicId { get; set; }
    }
}