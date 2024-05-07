using Nagarro.VendingMachine.PresentationLayer;
using VendingMachine.Business.Logging;

namespace Nagarro.VendingMachine.Payment
{
    internal class PaymentService : IPaymentService
    {
        private readonly IBuyView buyView;
        private readonly IEnumerable<IPaymentAlgorithm> paymentAlgorithms;
        private readonly List<PaymentMethod> paymentMethods;

        public PaymentService(IBuyView buyView, IEnumerable<IPaymentAlgorithm> paymentAlgorithms, ILogger<PaymentService> logger)
        {
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            this.paymentAlgorithms = paymentAlgorithms ?? throw new ArgumentNullException(nameof(paymentAlgorithms));

            paymentMethods = new List<PaymentMethod>();
            int id = 1;

            foreach (IPaymentAlgorithm paymentAlgorithm in paymentAlgorithms)
            {
                paymentMethods.Add(new PaymentMethod { Id = id, Name = paymentAlgorithm.Name });
                id++;
            }
        }

        public bool Execute(decimal price, out string paymentType)
        {

            int iterator = 0;

            int choice = buyView.AskForPaymentMethod(paymentMethods);

            foreach (IPaymentAlgorithm paymentAlgorithm in paymentAlgorithms)
            {
                iterator++;
                if (choice == iterator)
                {
                    return paymentAlgorithm.Run(price, out paymentType);
                }
            }

            paymentType = "fail";

            return false;
        }
    }
}