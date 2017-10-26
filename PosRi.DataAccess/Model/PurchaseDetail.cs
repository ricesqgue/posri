using System.ComponentModel.DataAnnotations.Schema;

namespace PosRi.DataAccess.Model
{
    public class PurchaseDetail
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public float SalePrice { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int PurchaseHeaderId { get; set; }
        [ForeignKey("PurchaseHeaderId")]
        public PurchaseHeader PurchaseHeader { get; set; }
    }
}