using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos
{
    public record GetSpecializationDto
    {
        public int id { get; init; }
        public string name { get; set; }
        public string description { get; set; }
    }
}
