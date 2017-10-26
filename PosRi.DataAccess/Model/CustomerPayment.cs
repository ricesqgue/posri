using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PosRi.DataAccess.Model
{
    public class CustomerPayment
    {
        public int Id { get; set; }

        public float Quantity { get; set; }

        public DateTime PaidDate { get; set; }

        public float PaidCash { get; set; }

        public float PaidCard { get; set; }

        public int CustomerDebtId { get; set; }
        [ForeignKey("CustomerDebtId")]
        public CustomerDebt CustomerDebt { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

    }
}