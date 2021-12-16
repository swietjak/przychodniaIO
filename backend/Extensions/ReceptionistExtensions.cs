using System.Collections.Generic;
using Backend.Dtos;
using Backend.Entities;
using System.Linq;

namespace Backend.Extensions
{
    public static class ReceptionistExtensions
    {
        public static GetReceptionistDto AsGetReceptionistDto(this Receptionist item, Clinic clinic)
        {
            return new GetReceptionistDto
            {
                id = item.id,
                name = item.name,
                address = item.address,
                mail = item.mail,
                phone = item.phone,
                PESEL = item.PESEL,
                clinic = clinic.AsGetEntityDto()
            };
        }

        public static Receptionist AsReceptionist(this CreateReceptionistDto item, Clinic clinic)
        {
            return new Receptionist
            {
                id = 0,
                name = item.name,
                address = item.address,
                mail = item.mail,
                phone = item.phone,
                PESEL = item.PESEL,
                clinic = clinic
            };
        }
    }
}