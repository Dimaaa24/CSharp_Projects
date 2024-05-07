using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nagarro.VendingMachine.Payment;
using Nagarro.VendingMachine.PresentationLayer;
using VendingMachine.Business.Logging;

namespace VendingMachine.Tests.PaymentTests.CardPaymentTests
{
    [TestClass]
    public class RunTests
    {
        private readonly Mock<ICardPaymentView> cardPaymentView;
        private readonly CardPayment cardPayment;

        public RunTests()
        {
            cardPaymentView = new Mock<ICardPaymentView>();

            cardPayment = new CardPayment(cardPaymentView.Object);
        }

        [TestMethod]
        public void HavingACardPaymentInstance_WhenRunIsCalled_UserIsAskedForCardNumber()
        {
            cardPaymentView
                .Setup(x => x.AskForCardNumber())
                .Returns("0000000000000000");

            cardPayment.Run(It.IsAny<decimal>(), out It.Ref<string>.IsAny);

            cardPaymentView.Verify(x => x.AskForCardNumber(), Times.Once());
        }

        [TestMethod]
        public void HavingACardPaymentInstance_WhenCardNumberIsNotValid_InvalidCardNumberIsCalled()
        {
            cardPaymentView
                .Setup(x => x.AskForCardNumber())
                .Returns("1000000000000000");
            cardPaymentView
                .Setup(x => x.CancelCardPayment())
                .Returns(1);

            cardPayment.Run(It.IsAny<decimal>(), out It.Ref<string>.IsAny);

            cardPaymentView.Verify(x => x.InvalidCardNumber(), Times.Once());
        }

        [TestMethod]
        public void HavingACardPaymentInstance_WhenCardNumberIsNotValid_CancelCardPaymentIsCalled()
        {
            cardPaymentView
                .Setup(x => x.AskForCardNumber())
                .Returns("1000000000000000");
            cardPaymentView
                .Setup(x => x.CancelCardPayment())
                .Returns(1);

            cardPayment.Run(It.IsAny<decimal>(), out It.Ref<string>.IsAny);

            cardPaymentView.Verify(x => x.CancelCardPayment(), Times.Once());
        }

        [TestMethod]
        public void HavingACardPayment_WhenCancelCardIsTrue_ReturnFalse()
        {
            cardPaymentView
                .Setup(x => x.AskForCardNumber())
                .Returns("1000000000000000");

            cardPaymentView
                .Setup(x => x.CancelCardPayment())
                .Returns(1);

            Assert.AreEqual(false, cardPayment.Run(It.IsAny<decimal>(), out It.Ref<string>.IsAny));
        }

        [TestMethod]
        public void HavingACardPaymentInstance_WhenCardNumberIsValid_CardAcceptedCalled()
        {
            cardPaymentView
                .Setup(x => x.AskForCardNumber())
                .Returns("0000000000000000");

            cardPayment.Run(It.IsAny<decimal>(), out It.Ref<string>.IsAny);

            cardPaymentView.Verify(x => x.CardAccepted(), Times.Once());
        }

        [TestMethod]
        public void HavingACardPaymentInstance_WhenCardNumberIsValid_TrueIsReturned()
        {
            cardPaymentView
                .Setup(x => x.AskForCardNumber())
                .Returns("0000000000000000");

            Assert.AreEqual(true, cardPayment.Run(It.IsAny<decimal>(), out It.Ref<string>.IsAny));
        }
    }
}