using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PosRi.DataAccess.Model
{
    public class CashRegisterMove
    {
        public int Id { get; set; }

        public string Action { get; set; }

        public DateTime RegisterDate { get; set; }

        public float Quantity { get; set; }

        public int CashRegisterId { get; set; }
        [ForeignKey("CashRegisterId")]
        public virtual CashRegister CashRegister { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}