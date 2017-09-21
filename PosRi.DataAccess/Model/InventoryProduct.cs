using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PosRi.DataAccess.Model
{
    public class InventoryProduct
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public DateTime LastAdd { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public int StoreId { get; set; }
        [ForeignKey("StoreId")]
        public virtual Store Store { get; set; }

    }
}