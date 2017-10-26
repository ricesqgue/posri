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

        public ICollection<Role> Roles { get; set; }

        public ICollection<PurchaseHeader> PurchaseHeaders { get; set; }

        public ICollection<SaleHeader> SaleHeaders { get; set; }

        public ICollection<CashRegisterMove> CashRegisterMoves { get; set; }

        public ICollection<CashFound> CashFounds { get; set; }

        public ICollection<CustomerPayment> CustomerPayments { get; set; }

        public ICollection<VendorPayment> VendorPayments { get; set; }


    }
}
