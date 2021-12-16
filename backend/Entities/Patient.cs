using System.ComponentModel.DataAnnotations;

namespace Backend.Entities
{
    public record Patient : User
    {
        [Required]
        public string insuranceId { get; set; }
    }
}