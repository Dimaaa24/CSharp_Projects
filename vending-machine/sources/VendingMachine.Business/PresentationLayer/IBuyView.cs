using Nagarro.VendingMachine.Payment;

namespace Nagarro.VendingMachine.PresentationLayer
{
    internal interface IBuyView
    {
        int ConfirmPay();

        void DispenseProduct(string productName);

        int RequestId();

        int AskForPaymentMethod(List<PaymentMethod> paymentMethods);

        void InvalidProductId(int id);

        void ConfirmPayError();
    }
}