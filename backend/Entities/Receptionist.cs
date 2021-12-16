using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Entities
{
    public record Receptionist : User
    {
        public Clinic clinic { get; set; }
    }
}
