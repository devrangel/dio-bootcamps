﻿namespace Domain.Repositories.Interfaces
{
    public interface IDeliveryFeeRepository
    {
        decimal Get(string zipCode);
    }
}
