using Nagarro.VendingMachine.PresentationLayer;
using VendingMachine.Business.Logging;

namespace Nagarro.VendingMachine.Payment
{
    internal class CardPayment : IPaymentAlgorithm
    {
        private readonly ICardPaymentView cardPaymentView;

        public string Name => "Card Payment";

        public CardPayment(ICardPaymentView cardPaymentView)
        {
            this.cardPaymentView = cardPaymentView ?? throw new ArgumentNullException(nameof(cardPaymentView));
        }

        private bool IsCardValid(string cardNumber)
        {
            if (cardNumber == "")
            {
                return false;
            }

            for (int i = 0; i < cardNumber.Length; i++)
            {
                if (!char.IsDigit(cardNumber[i]))
                {
                    return false;
                }
            }

            int sum = 0;
            int multiplier = 2;

            for (int i = cardNumber.Length - 1; i >= 0; i--)
            {
                multiplier = (multiplier == 2) ? 1 : 2;

                if (multiplier * (int)(cardNumber[i] - 48) >= 10)
                {
                    sum += (multiplier * (int)(cardNumber[i] - 48)) / 10 + (multiplier * (int)(cardNumber[i] - 48)) % 10;
                }
                else
                {
                    sum += multiplier * (int)(cardNumber[i] - 48);
                }
            }

            if (sum % 10 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Run(decimal price, out string paymentType)
        {
            paymentType = "card";

            string cardNumber = cardPaymentView.AskForCardNumber();
            int cancelCardPayment;

            while (!IsCardValid(cardNumber))
            {
                cardPaymentView.InvalidCardNumber();
                cancelCardPayment = cardPaymentView.CancelCardPayment();

                while (cancelCardPayment == -1)
                {
                    cardPaymentView.CancelCardPaymentError();
                    cancelCardPayment = cardPaymentView.CancelCardPayment();
                }

                if (cancelCardPayment == 0)
                {
                    cardNumber = cardPaymentView.AskForCardNumber();
                }
                else
                {
                    return false;
                }
            }

            cardPaymentView.CardAccepted();
            return true;
        }
    }
}