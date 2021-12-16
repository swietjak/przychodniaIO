using System;
using Backend.Entities;

namespace Backend.Dtos
{
    public record UpdateVisitDto
    {
        public DateTime startDate { get; set; }
        public int workingTimeId { get; set; }
        public int patientId { get; set; }
        public int receptionistId { get; set; }
        public string description { get; set; }
    }
}