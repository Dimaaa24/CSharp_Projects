using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nagarro.VendingMachine.Authentication;
using Nagarro.VendingMachine.UseCases;

namespace VendingMachine.Tests.UseCasesTests.LogoutUseCaseTests
{
    [TestClass]
    public class CanExecuteTests
    {
        private readonly Mock<IAuthenticationService> authenticationService;

        public CanExecuteTests()
        {
            authenticationService = new Mock<IAuthenticationService>();
        }

        [TestMethod]
        public void HavingNoAdminLoggedIn_CanExecuteIsFalse()
        {
            authenticationService
                .Setup(x => x.IsUserAuthenticated)
                .Returns(false);
            LogoutUseCase logoutUseCase = new LogoutUseCase(authenticationService.Object);

            Assert.IsFalse(logoutUseCase.CanExecute);
        }

        [TestMethod]
        public void HavingAdminLoggedIn_CanExecuteIsTrue()
        {
            authenticationService
               .Setup(x => x.IsUserAuthenticated)
               .Returns(true);
            LogoutUseCase logoutUseCase = new LogoutUseCase(authenticationService.Object);

            Assert.IsTrue(logoutUseCase.CanExecute);
        }
    }
}