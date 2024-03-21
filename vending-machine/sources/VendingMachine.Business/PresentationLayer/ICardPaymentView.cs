namespace Nagarro.VendingMachine.PresentationLayer
{
    internal interface ICardPaymentView
    {
        string AskForCardNumber();

        int CancelCardPayment();

        void InvalidCardNumber();

        void CardAccepted();

        void CancelCardPaymentError();
    }
}