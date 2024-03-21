using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nagarro.VendingMachine.Payment;
using Nagarro.VendingMachine.PresentationLayer;

namespace VendingMachine.Tests.PaymentTests.CashPaymentTests
{
    [TestClass]
    public class ConstructorTests
    {
        private readonly Mock<ICashPaymentView> cashPaymentView;

        public ConstructorTests()
        {
            cashPaymentView = new Mock<ICashPaymentView>();
        }

        [TestMethod]
        public void HavingANullCashPayment_ThenThrowException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                CashPayment cashPayment = new CashPayment(null);
            });
        }

        [TestMethod]
        public void WhenInitializingTheCardPayment_NameIsCorect()
        {
            CashPayment cashPayment = new CashPayment(cashPaymentView.Object);

            Assert.AreEqual("Cash Payment", cashPayment.Name);
        }
    }
}