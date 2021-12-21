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

        public static User AsUser(this CreateUserDto item)
        {
            return new User
            {
                address = item.address,
                id = 0,
                mail = item.mail,
                name = item.name,
                password = item.password,
                PESEL = item.PESEL,
                phone = item.phone
            };
        }

        public static Manager AsManager(this CreateUserDto item)
        {
            return new Manager
            {
                address = item.address,
                id = 0,
                mail = item.mail,
                name = item.name,
                password = item.password,
                PESEL = item.PESEL,
                phone = item.phone
            };
        }
    }
}