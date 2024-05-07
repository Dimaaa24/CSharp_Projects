using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nagarro.VendingMachine.Authentication;
using Nagarro.VendingMachine.Payment;
using Nagarro.VendingMachine.PresentationLayer;
using Nagarro.VendingMachine.UseCases;
using VendingMachine.Business.Logging;

namespace VendingMachine.Tests.UseCasesTests.LoginUseCaseTests
{
    [TestClass]
    public class ConstructorTests
    {
        private readonly Mock<IAuthenticationService> authenticationService;
        private readonly Mock<ILoginView> loginView;
        private readonly Mock<ILogger<LoginUseCase>> logger;

        public ConstructorTests()
        {
            authenticationService = new Mock<IAuthenticationService>();
            logger = new Mock<ILogger<LoginUseCase>>();
            loginView = new Mock<ILoginView>();
        }

        [TestMethod]
        public void HavingNullAuthenticationService_WhenCallingConstructor_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                LoginUseCase loginUseCase = new LoginUseCase(null, loginView.Object, logger.Object);
            });
        }

        [TestMethod]
        public void HavingNullLoginView_WhenCallingConstructor_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                LoginUseCase loginUseCase = new LoginUseCase(authenticationService.Object, null, logger.Object);
            });
        }
    }
}