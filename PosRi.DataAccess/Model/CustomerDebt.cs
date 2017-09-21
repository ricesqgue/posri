using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PosRi.DataAccess.Model
{
    public class CustomerDebt
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime DueDate { get; set; }

        public float Debt { get; set; }

        public float Balance { get; set; }

        public int SaleHeaderId { get; set; }
        [ForeignKey("SaleHeaderId")]
        public virtual SaleHeader SaleHeader { get; set; }
    }
}