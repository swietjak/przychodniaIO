using System;
using Backend.Entities;

namespace Backend.Dtos
{
    public record GetVisitDto
    {
        public int id { get; init; }
        public DateTime startDate { get; set; }

        public GetEntityDto doctor { get; set; }
        public GetEntityDto patient { get; set; }
        public GetEntityDto receptionist { get; set; }
        public string description { get; set; }
    }
}