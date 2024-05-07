using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nagarro.VendingMachine.Authentication;
using VendingMachine.Presentation;
using VendingMachine.Presentation.Commands;

namespace VendingMachine.Tests.CommandsTests.LogoutCommandTests
{
    [TestClass]
    public class ConstructorTests
    {
        private readonly Mock<IAuthenticationService> authenticationService;
        private readonly Mock<IUseCaseFactory> useCaseFactory;

        public ConstructorTests()
        {
            authenticationService = new Mock<IAuthenticationService>();
            useCaseFactory = new Mock<IUseCaseFactory>();
        }

        [TestMethod]
        public void WhenInitializingTheCommand_NameIsCorrect()
        {
            LogoutCommand logoutCommand = new LogoutCommand(authenticationService.Object, useCaseFactory.Object);

            Assert.AreEqual("logout", logoutCommand.Name);
        }

        [TestMethod]
        public void WhenInitializingTheCommand_DescriptionHasValue()
        {
            LogoutCommand logoutCommand = new LogoutCommand(authenticationService.Object, useCaseFactory.Object);

            Assert.IsNotNull(logoutCommand.Description);
        }

        [TestMethod]
        public void HavingANullAuthenticationService_WhenInitializingTheCommand_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new LogoutCommand(null, useCaseFactory.Object);
            });
        }

        [TestMethod]
        public void HavingANullUseCaseFactory_WhenInitializingTheCommand_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new LogoutCommand(authenticationService.Object, null);
            });
        }
    }
}