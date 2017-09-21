using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosRi.DataAccess.Model
{
    public class Customer
    {
        public int  Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Rfc { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime CreationDate { get; set; }

        public bool IsActive { get; set; }

        public int StateId { get; set; }
        [ForeignKey("StateId")]
        public virtual State State { get; set; }

    }
}
