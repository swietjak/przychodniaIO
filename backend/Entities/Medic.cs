using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Backend;

namespace Backend.Entities
{
    public record Medic : User
    {
        [Required]
        public MedicRole medicRole { get; set; }
        [Required]
        public ICollection<Specialization> specializations { get; set; }
        [Required]
        public ICollection<Clinic> clinics { get; set; }
    }
}