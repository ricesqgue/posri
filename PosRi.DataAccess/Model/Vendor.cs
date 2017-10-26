using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PosRi.DataAccess.Model
{
    public class Vendor
    {
        public int Id { get; set; }

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
        public State State { get; set; }

        public ICollection<Brand> Brands { get; set; }

        public ICollection<PurchaseHeader> PurchaseHeaders { get; set; }

        public ICollection<VendorDebt> VendorDebts { get; set; }


    }
}