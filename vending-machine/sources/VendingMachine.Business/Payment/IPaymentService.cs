﻿namespace Nagarro.VendingMachine.Payment
{
    internal interface IPaymentService
    {
        bool Execute(decimal price);
    }
}