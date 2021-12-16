using System.Collections.Generic;
using Backend.Dtos;
using Backend.Entities;
using System.Linq;

namespace Backend.Extensions
{
    public static class UserExtensions
    {
        public static GetUserDto AsGetUserDto(this User item)
        {
            return new GetUserDto
            {
                id = item.id,
                name = item.name,
                address = item.address,
                mail = item.mail,
                phone = item.phone,
                PESEL = item.PESEL
            };
        }
        public static GetEntityDto AsGetEntityDto(this User item)
        {
            return new GetEntityDto
            {
                id = item.id,
                name = item.name,
            };
        }
    }
}