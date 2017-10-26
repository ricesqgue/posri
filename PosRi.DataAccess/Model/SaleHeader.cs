using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PosRi.DataAccess.Model
{
    public class SaleHeader
    {
        public int Id { get; set; }

        public DateTime SaleDate { get; set; }

        public float SubTotal { get; set; }

        public float Total { get; set; }

        public float Discount { get; set; }

        public float PaidCash { get; set; }

        public float PaidCard { get; set; }

        public float PaidCredit { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        public int CashRegisterId { get; set; }
        [ForeignKey("CashRegisterId")]
        public CashRegister CashRegister { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public ICollection<SaleDetail> SaleDetails { get; set; }

    }
}
