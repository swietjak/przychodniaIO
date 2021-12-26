using System;
using System.Collections.Generic;

namespace Backend.Dtos
{
    public record LoginQuery
    {
        public string email { get; set; }
        public string password { get; set; }
    }

    public record LoginDto
    {
        public string role { get; set; }
        public int id { get; set; }
    }
}