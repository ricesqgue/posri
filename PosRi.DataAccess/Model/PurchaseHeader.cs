using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PosRi.DataAccess.Model
{
    public class PurchaseHeader
    {
        public int Id { get; set; }

        public DateTime PurchaseDate { get; set; }

        public float SubTotal { get; set; }

        public float Total { get; set; }

        public float Discount { get; set; }

        public float PaidCash { get; set; }

        public float PaidCard { get; set; }

        public float PaidCredit { get; set; }

        public int VendorId { get; set; }
        [ForeignKey("VendorId")]
        public Vendor Vendor { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public ICollection<PurchaseDetail> PurchaseDetails { get; set; }

    }
}
