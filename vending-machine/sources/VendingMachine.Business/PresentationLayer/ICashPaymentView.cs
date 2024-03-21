namespace Nagarro.VendingMachine.PresentationLayer
{
    internal interface ICashPaymentView
    {
        string AskForMoney(decimal productPrice, decimal currentBalance);

        void GiveBackChange(decimal currency, int counter);

        void TotalOwedBalance(decimal balance);

        void DisplayChangeOwed(decimal change);

        void InvalidBanknoteOrCoin();

        void CashPaymentCanceled(decimal paidMoney);
    }
}