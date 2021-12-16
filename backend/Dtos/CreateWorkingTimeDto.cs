using System;
using System.Collections.Generic;

namespace Backend.Dtos
{
    public record CreateWorkingTimeDto
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int medicId { get; set; }
        public int clinicId { get; set; }
    }
}