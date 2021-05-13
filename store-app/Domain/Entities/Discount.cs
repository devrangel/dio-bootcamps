﻿using System;

namespace Domain.Entities
{
    class Discount : Entity
    {
        public decimal Amount { get; private set; }
        public DateTime ExpireDate { get; private set; }

        public Discount(decimal amount, DateTime expireDate)
        {
            Amount = amount;
            ExpireDate = expireDate;
        }

        public bool IsValid()
        {
            return DateTime.Compare(DateTime.Now, ExpireDate) < 0;
        }

        public decimal Value()
        {
            if (IsValid())
                return Amount;
            else
                return 0;
        }
    }
}
