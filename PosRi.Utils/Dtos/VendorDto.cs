using PosRi.DataAccess.Model;
using System;
using System.Collections.Generic;

namespace PosRi.Utils.Dtos
{
    public class VendorDto
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

        public ICollection<BrandDto> Brands { get; set; } 

        public VendorDto()
        {

        }

        public VendorDto(Vendor vendor)
        {
            Id = vendor.Id;
            Name = vendor.Name;
            Address = vendor.Address;
            City = vendor.City;
            Rfc = vendor.Rfc;
            Email = vendor.Email;
            Phone = vendor.Phone;
            CreationDate = vendor.CreationDate;
            State = vendor.State;
            Brands = new List<BrandDto>();

            foreach (var vendorBrand in vendor.Brands)
            {
                Brands.Add(new BrandDto(vendorBrand));
            }
            
        }
    }
}
