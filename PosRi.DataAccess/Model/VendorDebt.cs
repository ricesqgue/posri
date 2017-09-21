using System;
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
        public virtual PurchaseHeader PurchaseHeader { get; set; }
    }
}