using System.Collections.Generic;
using Backend.Dtos;
using Backend.Entities;
using System.Linq;

namespace Backend.Extensions
{
    public static class PatientExtensions
    {
        public static Patient AsPatient(this CreatePatientDto item, List<Specialization> specializations, List<Clinic> clinics)
        {
            return new Patient
            {
                id = 0,
                name = item.name,
                address = item.address,
                mail = item.mail,
                password = item.password,
                PESEL = item.PESEL,
                phone = item.phone,
                insuranceId = item.insuranceId
            };
        }

        public static GetPatientDto AsGetPatientDto(this Patient item)
        {

            return new GetPatientDto
            {
                id = item.id,
                name = item.name,
                address = item.address,
                mail = item.mail,
                PESEL = item.PESEL,
                phone = item.phone,
                insuranceId = item.insuranceId
            };
        }
    }
}