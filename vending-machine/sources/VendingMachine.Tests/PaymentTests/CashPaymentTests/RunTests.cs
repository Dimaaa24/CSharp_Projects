using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nagarro.VendingMachine.Payment;
using Nagarro.VendingMachine.PresentationLayer;
using VendingMachine.Business.Logging;

namespace VendingMachine.Tests.PaymentTests.CashPaymentTests
{
    [TestClass]
    public class RunTests
    {
        private readonly Mock<ICashPaymentView> cashPaymentView;
        private readonly CashPayment cashPayment;

        public RunTests()
        {
            cashPaymentView = new Mock<ICashPaymentView>();

            cashPayment = new CashPayment(cashPaymentView.Object);
        }

        [TestMethod]
        public void HavingACashPaymentInstance_WhenRunIsCalled_UserIsAskedToInputMoney()
        {
            cashPaymentView
                .Setup(x => x.AskForMoney(It.IsAny<decimal>(), It.IsAny<decimal>()))
                .Returns("10");

            cashPayment.Run(30, out It.Ref<string>.IsAny);

            cashPaymentView.Verify(x => x.AskForMoney(It.IsAny<decimal>(), It.IsAny<decimal>()), Times.Exactly(3));
        }

        [TestMethod]
        public void HavingACashPaymentInstance_WhenTooMuchMoneyIsInserted_ThenUserIsPaidBackChange()
        {
            cashPaymentView
                .Setup(x => x.AskForMoney(It.IsAny<decimal>(), It.IsAny<decimal>()))
                .Returns("50");

            cashPayment.Run(34.45m, out It.Ref<string>.IsAny);

            cashPaymentView.Verify(x => x.GiveBackChange(10, 1), Times.Once());
            cashPaymentView.Verify(x => x.GiveBackChange(5, 1), Times.Once());
            cashPaymentView.Verify(x => x.GiveBackChange(0.50m, 1), Times.Once());
            cashPaymentView.Verify(x => x.GiveBackChange(0.05m, 1), Times.Once());
        }
    }
}