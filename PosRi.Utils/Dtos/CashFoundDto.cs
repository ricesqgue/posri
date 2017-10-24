using PosRi.DataAccess.Model;
using System;

namespace PosRi.Utils.Dtos
{
    public class CashFoundDto
    {
        public int Id { get; set; }

        public DateTime RegisterDate { get; set; }

        public float Quantity { get; set; }

        public UserDto User { get; set; }

        public CashRegisterDto CashRegister { get; set; }

        public CashFoundDto()
        {

        }

        public CashFoundDto(CashFound cashFound )
        {
            Id = cashFound.Id;
            RegisterDate = cashFound.RegisterDate;
            Quantity = cashFound.Quantity;
            User = new UserDto(cashFound.User);
            CashRegister = new CashRegisterDto(cashFound.CashRegister);
        }
    }


}
