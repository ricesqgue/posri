using PosRi.DataAccess.Model;
using System;

namespace PosRi.Utils.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Rfc { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime CreationDate { get; set; }

        public State State { get; set; }

        public CustomerDto()
        {
            
        }

        public CustomerDto(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            Address = customer.Address;
            City = customer.City;
            Rfc = customer.Rfc;
            Email = customer.Email;
            Phone = customer.Phone;
            CreationDate = customer.CreationDate;
            State = customer.State;
        }
    }
}