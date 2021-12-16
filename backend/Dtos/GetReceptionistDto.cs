using System.Collections.Generic;

namespace Backend.Dtos
{
    public record GetReceptionistDto : GetUserDto
    {
        public GetEntityDto clinic { get; set; }
    }
}
