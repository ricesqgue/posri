using System.Collections.Generic;

namespace PosRi.DataAccess.Model
{
    public class State
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Customer> Customers { get; set; }

        public ICollection<Vendor> Vendors { get; set; }

        public State()
        {
            
        }

        public State(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}