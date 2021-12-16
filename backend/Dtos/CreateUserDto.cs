using System.Collections.Generic;

namespace Backend.Dtos
{
    public record CreateUserDto
    {
        public string name { get; set; }
        public string address { get; set; }
        public string mail { get; set; }
        public string phone { get; set; }
        public string PESEL { get; set; }
        public string password { get; set; }
    }
}