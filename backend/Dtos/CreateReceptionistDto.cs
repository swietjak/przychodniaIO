using System.Collections.Generic;

namespace Backend.Dtos
{
    public record CreateReceptionistDto : CreateUserDto
    {
        public int receptionistId { get; set; }
    }
}
