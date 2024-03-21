using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nagarro.VendingMachine.Authentication;
using Nagarro.VendingMachine.DataAccess;
using Nagarro.VendingMachine.Payment;
using Nagarro.VendingMachine.PresentationLayer;
using Nagarro.VendingMachine.UseCases;

namespace VendingMachine.Tests.UseCasesTests.BuyUseCaseTests
{
    [TestClass]
    public class ConstructorTests
    {
        private readonly Mock<IAuthenticationService> authenticationService;
        private readonly Mock<IProductRepository> productRepository;
        private readonly Mock<IPaymentService> paymentService;
        private readonly Mock<IBuyView> buyView;

        public ConstructorTests()
        {
            authenticationService = new Mock<IAuthenticationService>();
            productRepository = new Mock<IProductRepository>();
            paymentService = new Mock<IPaymentService>();
            buyView = new Mock<IBuyView>();
        }

        [TestMethod]
        public void HavingANullAuthenticationService_WhenCallingConstructor_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                BuyUseCase buyUseCase = new BuyUseCase(null, buyView.Object, productRepository.Object, paymentService.Object);
            });
        }

        [TestMethod]
        public void HavingANullBuyView_WhenCallingConstructor_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                BuyUseCase buyUseCase = new BuyUseCase(authenticationService.Object, null, productRepository.Object, paymentService.Object);
            });
        }

        [TestMethod]
        public void HavingANullProductRepository_WhenCallingConstructor_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                BuyUseCase buyUseCase = new BuyUseCase(authenticationService.Object, buyView.Object, null, paymentService.Object);
            });
        }

        [TestMethod]
        public void HavingANullPaymentService_WhenCallingConstructor_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                BuyUseCase buyUseCase = new BuyUseCase(authenticationService.Object, buyView.Object, productRepository.Object, null);
            });
        }

        [TestMethod]
        public void WhenInitializingTheUseCase_NameIsCorect()
        {
            BuyUseCase buyUseCase = new BuyUseCase(authenticationService.Object, buyView.Object, productRepository.Object, paymentService.Object);

            Assert.AreEqual("buy", buyUseCase.Name);
        }

        [TestMethod]
        public void WhenInitializingTheUseCase_DescriptionHasValue()
        {
            BuyUseCase buyUseCase = new BuyUseCase(authenticationService.Object, buyView.Object, productRepository.Object, paymentService.Object);

            Assert.IsNotNull(buyUseCase.Description);
        }
    }
}