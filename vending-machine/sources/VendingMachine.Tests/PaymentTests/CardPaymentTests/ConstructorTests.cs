using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nagarro.VendingMachine.Payment;
using Nagarro.VendingMachine.PresentationLayer;

namespace VendingMachine.Tests.PaymentTests.CardPaymentTests
{
    [TestClass]
    public class ConstructorTests
    {
        private readonly Mock<ICardPaymentView> cardPaymentView;

        public ConstructorTests()
        {
            cardPaymentView = new Mock<ICardPaymentView>();
        }

        [TestMethod]
        public void HavingANullCardPayment_ThenThrowException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                CardPayment cardPayment = new CardPayment(null);
            });
        }

        [TestMethod]
        public void WhenInitializingTheCardPayment_NameIsCorect()
        {
            CardPayment cardPayment = new CardPayment(cardPaymentView.Object);

            Assert.AreEqual("Card Payment", cardPayment.Name);
        }
    }
}