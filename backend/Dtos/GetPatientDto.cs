using System.Collections.Generic;

namespace Backend.Dtos
{
    public record GetPatientDto : GetUserDto
    {
        public string insuranceId { get; set; }
    }
}
