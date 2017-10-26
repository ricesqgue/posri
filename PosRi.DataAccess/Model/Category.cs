using System.Collections.Generic;

namespace PosRi.DataAccess.Model
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public ICollection<ProductHeader> ProductHeaders { get; set; }
    }
}