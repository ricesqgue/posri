using System.Collections.Generic;

namespace PosRi.DataAccess.Model
{
    public class Store
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<CashRegister> CashRegisters { get; set;  }

    }
}
