using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PosRi.DataAccess.Model
{
    public class VendorDebt
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime DueDate { get; set; }

        public float Debt { get; set; }

        public float Balance { get; set; }

        public int PurchaseHeaderId { get; set; }
        [ForeignKey("PurchaseHeaderId")]
        public PurchaseHeader PurchaseHeader { get; set; }

        public int VendorId { get; set; }
        [ForeignKey("VendorId")]
        public Vendor Vendor { get; set; }

        public ICollection<VendorPayment> VendorPayments { get; set; }
    }
}