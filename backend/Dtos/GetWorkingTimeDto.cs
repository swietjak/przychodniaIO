using System;
using System.Collections.Generic;

namespace Backend.Dtos
{
    public record GetWorkingTimeDto
    {
        public int id { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public GetEntityDto medic { get; set; }
        public GetEntityDto clinic { get; set; }
    }
}