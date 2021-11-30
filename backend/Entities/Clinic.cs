using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Entities
{
    public record Clinic
    {
        [Key]
        public int id { get; init; }
        [Required]
        public string name { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string mail { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public string menager_id { get; set; }
        [Required]
        public Specialization specialization { get; set; }
    }
}