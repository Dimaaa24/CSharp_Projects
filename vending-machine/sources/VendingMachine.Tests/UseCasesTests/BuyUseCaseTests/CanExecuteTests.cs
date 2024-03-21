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
    public class CanExecuteTests
    {
        private readonly Mock<IAuthenticationService> authenticationService;
        private readonly Mock<IProductRepository> productRepository;
        private readonly Mock<IPaymentService> paymentService;
        private readonly Mock<IBuyView> buyView;

        public CanExecuteTests()
        {
            authenticationService = new Mock<IAuthenticationService>();
            productRepository = new Mock<IProductRepository>();
            paymentService = new Mock<IPaymentService>();
            buyView = new Mock<IBuyView>();
        }

        [TestMethod]
        public void HavingNoAdminLoggedIn_ThenCanExecuteIsTrue()
        {
            authenticationService
                .Setup(x => x.IsUserAuthenticated)
                .Returns(false);

            BuyUseCase buyUseCase = new BuyUseCase(authenticationService.Object, buyView.Object, productRepository.Object, paymentService.Object);

            Assert.IsTrue(buyUseCase.CanExecute);
        }

        [TestMethod]
        public void HavingAdminLoggedIn_ThenCanExecuteIsFalse()
        {
            authenticationService
                .Setup(x => x.IsUserAuthenticated)
                .Returns(true);

            BuyUseCase buyUseCase = new BuyUseCase(authenticationService.Object, buyView.Object, productRepository.Object, paymentService.Object);

            Assert.IsFalse(buyUseCase.CanExecute);
        }
    }
}