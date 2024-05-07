using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nagarro.VendingMachine.Payment;
using Nagarro.VendingMachine.PresentationLayer;
using VendingMachine.Business.Logging;

namespace VendingMachine.Tests.PaymentTests.PaymentServiceTests
{
    [TestClass]
    public class ExecuteTests
    {
        private readonly Mock<IBuyView> buyView;
        private readonly Mock<IPaymentAlgorithm> cardPayment;
        private readonly Mock<IPaymentAlgorithm> cashPayment;
        private readonly Mock<ILogger<PaymentService>> logger;
        private readonly IEnumerable<IPaymentAlgorithm> paymentAlgorithms;
        private readonly PaymentService paymentService;

        public ExecuteTests()
        {
            buyView = new Mock<IBuyView>();
            cardPayment = new Mock<IPaymentAlgorithm>();
            cashPayment = new Mock<IPaymentAlgorithm>();
            paymentAlgorithms = new List<IPaymentAlgorithm>
            {
                cashPayment.Object,
                cardPayment.Object
            };
            logger = new Mock<ILogger<PaymentService>>();
            paymentService = new PaymentService(buyView.Object, paymentAlgorithms, logger.Object);
        }

        [TestMethod]
        public void HavingAPaymentServiceInstance_WhenExecuted_ThenAskForPaymentIsCalled()
        {
            buyView
                .Setup(x => x.AskForPaymentMethod(It.IsAny<List<PaymentMethod>>()))
                .Returns(1);

            paymentService.Execute(It.IsAny<decimal>(), out It.Ref<string>.IsAny);

            buyView.Verify(x => x.AskForPaymentMethod(It.IsAny<List<PaymentMethod>>()), Times.Once());
        }

        [TestMethod]
        public void HavingAPaymentServiceInstance_WhenChoiceIsWrong_ThenReturnFalse()
        {
            buyView
                .Setup(x => x.AskForPaymentMethod(It.IsAny<List<PaymentMethod>>()))
                .Returns(3);

            Assert.AreEqual(false, paymentService.Execute(It.IsAny<decimal>(), out It.Ref<string>.IsAny));
        }

        [TestMethod]
        public void HavingAPaymentServiceInstance_WhenChoiceIsOne_ThenCashPaymentIsRun()
        {
            buyView
                .Setup(x => x.AskForPaymentMethod(It.IsAny<List<PaymentMethod>>()))
                .Returns(1);

            paymentService.Execute(It.IsAny<decimal>(), out It.Ref<string>.IsAny);

            cashPayment.Verify(x => x.Run(It.IsAny<decimal>(), out It.Ref<string>.IsAny), Times.Once());
        }

        [TestMethod]
        public void HavingAPaymentServiceInstance_WhenChoiceIsTwo_ThenCardPaymentIsRun()
        {
            buyView
                .Setup(x => x.AskForPaymentMethod(It.IsAny<List<PaymentMethod>>()))
                .Returns(2);

            paymentService.Execute(It.IsAny<decimal>(), out It.Ref<string>.IsAny);

            cardPayment.Verify(x => x.Run(It.IsAny<decimal>(), out It.Ref<string>.IsAny), Times.Once());
        }
    }
}