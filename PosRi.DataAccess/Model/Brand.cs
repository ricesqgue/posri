using System.Collections.Generic;

namespace PosRi.DataAccess.Model
{
    public class Brand
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<ProductHeader> ProductHeaders { get; set; }

        public ICollection<Vendor> Vendors { get; set; }

        public bool IsActive { get; set; }

    }
}