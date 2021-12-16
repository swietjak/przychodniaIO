using System.Collections.Generic;

namespace Backend.Dtos
{
    public record GetMedicDto : GetUserDto
    {
        public string medicRole { get; set; }
        public IEnumerable<GetEntityDto> specializations { get; set; }
        public IEnumerable<GetEntityDto> clinics { get; set; }
    }
}