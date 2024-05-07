using log4net.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nagarro.VendingMachine.Payment;
using Nagarro.VendingMachine.PresentationLayer;
using VendingMachine.Business.Logging;

namespace VendingMachine.Tests.PaymentTests.PaymentServiceTests
{
    [TestClass]
    public class ConstructorTests
    {
        private readonly Mock<IBuyView> buyView;
        private readonly Mock<IPaymentAlgorithm> cardPayment;
        private readonly Mock<IPaymentAlgorithm> cashPayment;
        private readonly Mock<ILogger<PaymentService>> logger;
        private readonly List<IPaymentAlgorithm> paymentAlgorithms;

        public ConstructorTests()
        {
            cardPayment = new Mock<IPaymentAlgorithm>();
            cashPayment = new Mock<IPaymentAlgorithm>();
            logger = new Mock<ILogger<PaymentService>>();
            paymentAlgorithms = new List<IPaymentAlgorithm>
            {
                cardPayment.Object,
                cashPayment.Object,
            };
            buyView = new Mock<IBuyView>();
        }

        [TestMethod]
        public void HavingANullBuyView_ThenThrowException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                PaymentService paymentService = new PaymentService(null, paymentAlgorithms, logger.Object);
            });
        }

        [TestMethod]
        public void HavingANullPaymentAlgorithmsList_ThenThrowException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                PaymentService paymentService = new PaymentService(buyView.Object, null, logger.Object);
            });
        }
    }
}