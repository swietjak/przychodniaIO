using System.Collections.Generic;
using Backend.Dtos;
using Backend.Entities;
using System.Linq;

namespace Backend.Extensions
{
    public static class SpecializationsExtensions
    {
        public static GetClinicDto AsGetClinicDto(this Clinic item)
        {
            return new GetClinicDto
            {
                id = item.id,
                name = item.name,
                address = item.address,
                mail = item.mail,
                menager_id = item.menager_id,
                phone = item.phone,
                specialization = new GetSpecializationDto
                {
                    id = item.specialization.id,
                    name = item.specialization.name,
                    description = item.specialization.description,
                }
            };
        }



        public static GetSpecializationDto AsGetSpecializationDto(this Specialization item)
        {
            return new GetSpecializationDto
            {
                id = item.id,
                name = item.name,
                description = item.description,
            };
        }

        public static GetEntityDto AsGetEntityDto(this Specialization item)
        {
            return new GetEntityDto
            {
                id = item.id,
                name = item.name,
            };
        }



        public static Specialization AsSpecialization(this CreateSpecializationDto item)
        {
            return new Specialization
            {
                id = 0,
                name = item.name,
                description = item.description
            };
        }
    }
}