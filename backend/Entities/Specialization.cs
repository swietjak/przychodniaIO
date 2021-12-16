using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Backend.Entities
{
    public record Specialization
    {
        [Key]
        public int id { get; init; }
        [Required]
        public string name { get; set; }
        public string description { get; set; }
        public ICollection<Medic> medics { get; set; }
    }
}
