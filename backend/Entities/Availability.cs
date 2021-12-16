using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Entities
{
    public record Availability
    {
        [Key]
        public int id { get; init; }
        [Required]
        public DateTime startDate { get; set; }
        [Required]
        public DateTime endDate { get; set; }
        [Required]
        public Medic medic { get; set; }
    }
}