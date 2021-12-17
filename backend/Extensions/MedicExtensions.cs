using System.Collections.Generic;
using Backend.Dtos;
using Backend.Entities;
using System.Linq;

namespace Backend.Extensions
{
    public static class MedicExtensions
    {
        public static Medic AsMedic(this CreateMedicDto item, List<Specialization> specializations, List<Clinic> clinics)
        {
            return new Medic
            {
                id = 0,
                name = item.name,
                address = item.address,
                clinics = clinics,
                mail = item.mail,
                password = item.password,
                PESEL = item.PESEL,
                phone = item.phone,
                specializations = specializations,
                medicRole = (MedicRole)System.Enum.Parse(typeof(MedicRole), item.role)
            };
        }

        public static GetMedicDto AsGetMedicDto(this Medic item, IEnumerable<GetEntityDto> clinics, IEnumerable<GetEntityDto> specilizations)
        {
            System.Console.WriteLine(item.medicRole.ToString("G"));
            return new GetMedicDto
            {
                id = item.id,
                name = item.name,
                address = item.address,
                clinics = clinics,
                mail = item.mail,
                PESEL = item.PESEL,
                phone = item.phone,
                specializations = specilizations,
                medicRole = item.medicRole.ToString("G")
            };
        }

        public static GetMedicDto AsGetMedicDto(this Medic item)
        {
            //System.Console.WriteLine(item.medicRole.ToString("G"));
            return new GetMedicDto
            {
                id = item.id,
                name = item.name,
                address = item.address,
                clinics = item.clinics.Select(clinic => clinic.AsGetEntityDto()),
                mail = item.mail,
                PESEL = item.PESEL,
                phone = item.phone,
                specializations = item.specializations.Select(specialization => specialization.AsGetEntityDto()),
                medicRole = item.medicRole.ToString("G")
            };
        }
    }
}