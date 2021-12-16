using System;
using System.Collections.Generic;

namespace Backend.Dtos
{
    public record GetWorkingTimeDto
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public GetEntityDto user { get; set; }
        public GetEntityDto clinic { get; set; }
    }
}