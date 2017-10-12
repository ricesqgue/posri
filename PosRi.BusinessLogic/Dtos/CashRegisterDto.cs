using PosRi.DataAccess.Model;
using System.ComponentModel.DataAnnotations;

namespace PosRi.BusinessLogic.Dtos
{
    public class CashRegisterDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public CashRegisterDto()
        {
            
        }

        public CashRegisterDto(CashRegister cashRegister)
        {
            Id = cashRegister.Id;
            Name = cashRegister.Name;
        }
    }
}
