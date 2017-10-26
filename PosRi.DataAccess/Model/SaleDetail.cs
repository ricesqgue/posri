using System.ComponentModel.DataAnnotations.Schema;

namespace PosRi.DataAccess.Model
{
    public class SaleDetail
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public float SalePrice { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int SaleHeaderId { get; set; }
        [ForeignKey("SaleHeaderId")]
        public SaleHeader SaleHeader { get; set; }
    }
}