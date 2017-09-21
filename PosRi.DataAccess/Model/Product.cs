using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public virtual Size Size { get; set; }

        public int ColorId { get; set; }
        [ForeignKey("ColorId")]
        public virtual Color Color { get; set; }

        public int ProductHeaderId { get; set; }
        [ForeignKey("ProductHeaderId")]
        public virtual ProductHeader ProductHeader { get; set; }


    }
}
