using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PosRi.DataAccess.Model
{
    public class VendorPayment
    {
        public int Id { get; set; }

        public float Quantity { get; set; }

        public DateTime PaidDate { get; set; }

        public float PaidCash { get; set; }

        public float PaidCard { get; set; }

        public int VendorDebtId { get; set; }
        [ForeignKey("VendorDebtId")]
        public VendorDebt VendorDebt { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

    }
}