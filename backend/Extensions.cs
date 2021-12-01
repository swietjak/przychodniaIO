using Backend.Dtos;
using Backend.Entities;

namespace Backend
{
    public static class Extensions
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