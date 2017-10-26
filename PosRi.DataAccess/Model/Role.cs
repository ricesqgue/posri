using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PosRi.DataAccess.Model
{
    public class Role
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }

        public Role()
        {
            
        }

        private Role(RoleNames @enum)
        {
            Id = (int)@enum;
            Name = @enum.ToString();
        }

        public static implicit operator RoleNames(Role role)
        {
            return (RoleNames) role.Id;
        }

        public static implicit operator Role(RoleNames @enum)
        {
            return new Role(@enum);
        }

    }

    public enum RoleNames
    {
        SuperAdmmin = 1,
        Administrador = 2,
        Vendedor = 3,
        Comprador = 4,
        Gerente = 5

    }
}
