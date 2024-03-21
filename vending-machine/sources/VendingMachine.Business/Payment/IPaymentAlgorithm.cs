namespace Nagarro.VendingMachine.Payment
{
    internal interface IPaymentAlgorithm
    {
        string Name { get; }

        bool Run(decimal price);
    }
}