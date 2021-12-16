using System.Collections.Generic;
using Backend.Dtos;
using Backend.Entities;
using System.Linq;

namespace Backend.Extensions
{
    public static class ClinicExtensions
    {
        public static GetClinicDto AsGetClinicDto(this Clinic item, Specialization specialization)
        {
            return new GetClinicDto
            {
                id = item.id,
                name = item.name,
                address = item.address,
                mail = item.mail,
                menager_id = item.menager_id,
                phone = item.phone,
                specialization = specialization.AsGetSpecializationDto()
            };
        }
        public static GetEntityDto AsGetEntityDto(this Clinic item)
        {
            return new GetEntityDto
            {
                id = item.id,
                name = item.name,
            };
        }

        public static Clinic AsClinic(this CreateClinicDto item, Specialization specialization)
        {
            return new Clinic
            {
                id = 0,
                name = item.name,
                address = item.address,
                mail = item.mail,
                menager_id = item.menager_id,
                phone = item.phone,
                specialization = specialization
            };
        }
    }
}