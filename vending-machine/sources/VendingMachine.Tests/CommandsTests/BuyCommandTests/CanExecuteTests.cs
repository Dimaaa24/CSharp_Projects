using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nagarro.VendingMachine.Authentication;
using VendingMachine.Presentation;
using VendingMachine.Presentation.Commands;

namespace VendingMachine.Tests.CommandsTests.BuyCommandTests
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
        public void HavingNoAdminLoggedIn_ThenCanExecuteIsTrue()
        {
            authenticationService
            .Setup(x => x.IsUserAuthenticated)
            .Returns(false);
            BuyCommand buyCommand = new BuyCommand(authenticationService.Object, useCaseFactory.Object);
            Assert.IsTrue(buyCommand.CanExecute);
        }

        [TestMethod]
        public void HavingAdminLoggedIn_ThenCanExecuteIsFalse()
        {
            authenticationService
            .Setup(x => x.IsUserAuthenticated)
            .Returns(true);
            BuyCommand buyCommand = new BuyCommand(authenticationService.Object, useCaseFactory.Object);

            Assert.IsFalse(buyCommand.CanExecute);
        }
    }
}