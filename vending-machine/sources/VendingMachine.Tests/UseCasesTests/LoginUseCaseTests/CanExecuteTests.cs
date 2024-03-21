using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nagarro.VendingMachine.Authentication;
using Nagarro.VendingMachine.PresentationLayer;
using Nagarro.VendingMachine.UseCases;

namespace VendingMachine.Tests.UseCasesTests.LoginUseCaseTests
{
    [TestClass]
    public class CanExecuteTests
    {
        private readonly Mock<IAuthenticationService> authenticationService;
        private readonly Mock<ILoginView> loginView;

        public CanExecuteTests()
        {
            authenticationService = new Mock<IAuthenticationService>();
            loginView = new Mock<ILoginView>();
        }

        [TestMethod]
        public void HavingNoAdminLoggedIn_ThenCanExecuteIsTrue()
        {
            authenticationService
                .Setup(x => x.IsUserAuthenticated)
                .Returns(false);

            LoginUseCase loginUseCase = new LoginUseCase(authenticationService.Object, loginView.Object);

            Assert.IsTrue(loginUseCase.CanExecute);
        }

        [TestMethod]
        public void HavingAdminLoggedIn_ThenCanExecuteIsFalse()
        {
            authenticationService
                .Setup(x => x.IsUserAuthenticated)
                .Returns(true);

            LoginUseCase loginUseCase = new LoginUseCase(authenticationService.Object, loginView.Object);

            Assert.IsFalse(loginUseCase.CanExecute);
        }
    }
}