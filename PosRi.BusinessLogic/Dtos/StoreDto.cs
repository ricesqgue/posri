using PosRi.DataAccess.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PosRi.BusinessLogic.Dtos
{
    public class StoreDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public ICollection<CashRegisterDto> CashRegisters { get; set; }

        public StoreDto()
        {
            
        }

        public StoreDto(Store store)
        {
            Id = store.Id;
            Name = store.Name;
            Address = store.Address;
            Phone = store.Phone;
            CashRegisters = new List<CashRegisterDto>();

            foreach (var cashRegister in store.CashRegisters)
            {
               CashRegisters.Add(new CashRegisterDto(cashRegister)); 
            }

        }
    }
}
