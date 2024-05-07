using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nagarro.VendingMachine.Authentication;
using VendingMachine.Presentation;
using VendingMachine.Presentation.Commands;

namespace VendingMachine.Tests.CommandsTests.LogoutCommandTests
{
    [TestClass]
    public class CanExecuteTests
    {
        private readonly Mock<IAuthenticationService> authenticationService;
        private readonly Mock<IUseCaseFactory> useCaseFactory;

        public CanExecuteTests()
        {
            authenticationService = new Mock<IAuthenticationService>();
            useCaseFactory = new Mock<IUseCaseFactory>();
        }

        [TestMethod]
        public void HavingNoAdminLoggedIn_CanExecuteIsFalse()
        {
            authenticationService
                .Setup(x => x.IsUserAuthenticated)
                .Returns(false);
            LogoutCommand logoutCommand = new LogoutCommand(authenticationService.Object, useCaseFactory.Object);

            Assert.IsFalse(logoutCommand.CanExecute);
        }

        [TestMethod]
        public void HavingAdminLoggedIn_CanExecuteIsTrue()
        {
            authenticationService
               .Setup(x => x.IsUserAuthenticated)
               .Returns(true);
            LogoutCommand logoutCommand = new LogoutCommand(authenticationService.Object, useCaseFactory.Object);

            Assert.IsTrue(logoutCommand.CanExecute);
        }
    }
}