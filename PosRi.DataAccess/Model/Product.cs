using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PosRi.DataAccess.Model
{
    public class Product
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string ExtraDescription { get; set; }

        public bool IsActive { get; set; }

        public float PurchasePrice { get; set; }

        public float Price { get; set; }

        public float SpecialPrice { get; set; }

        public DateTime CreateDate { get; set; }

        public int SizeId { get; set; }
        [ForeignKey("SizeId")]
        public Size Size { get; set; }

        public int ColorId { get; set; }
        [ForeignKey("ColorId")]
        public Color Color { get; set; }

        public int ProductHeaderId { get; set; }
        [ForeignKey("ProductHeaderId")]
        public ProductHeader ProductHeader { get; set; }


    }
}
