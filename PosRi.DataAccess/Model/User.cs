using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PosRi.DataAccess.Model
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        
    }
}
