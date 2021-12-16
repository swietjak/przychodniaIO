using System.ComponentModel.DataAnnotations;

namespace Backend.Entities
{
    public record User
    {
        [Key]
        public int id { get; init; }
        [Required]
        public string name { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string mail { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public string PESEL { get; set; }
    }
}