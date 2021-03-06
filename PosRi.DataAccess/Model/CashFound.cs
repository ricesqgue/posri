﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PosRi.DataAccess.Model
{
    public class CashFound
    {
        public int Id { get; set; }

        public DateTime RegisterDate { get; set; }

        public float Quantity { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public int CashRegisterId { get; set; }
        [ForeignKey("CashRegisterId")]
        public CashRegister CashRegister { get; set; }
    }
}