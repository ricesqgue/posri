using PosRi.DataAccess.Model;
using System;
using System.Collections.Generic;

namespace PosRi.BusinessLogic.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public DateTime Birthday { get; set; }

        public DateTime HireDate { get; set; }

        public ICollection<Role> Roles { get; set; }



        public UserDto()
        {
            
        }

        public UserDto(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Birthday = user.Birthday;
            HireDate = user.HireDate;
            Roles = user.Roles;
        }
    }

    
}
