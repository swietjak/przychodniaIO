using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Entities
{
    public record Visit
    {
        [Key]
        public int id { get; init; }
        [Required]
        public DateTime startDate { get; set; }
        [Required]
        public WorkingTime workingTime { get; set; }
        public Patient patient { get; set; }
        public Receptionist receptionist { get; set; }
        public string description { get; set; }
    }
}