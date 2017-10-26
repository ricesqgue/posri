using System.Collections.Generic;

namespace PosRi.DataAccess.Model
{
    public class Color
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}