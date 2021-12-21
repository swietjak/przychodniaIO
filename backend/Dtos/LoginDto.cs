using System;
using System.Collections.Generic;

namespace Backend.Dtos
{
    public record LoginDto
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}