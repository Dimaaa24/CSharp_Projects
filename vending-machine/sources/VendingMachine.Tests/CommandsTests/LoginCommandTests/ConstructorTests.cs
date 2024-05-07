using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nagarro.VendingMachine.Authentication;
using VendingMachine.Presentation;
using VendingMachine.Presentation.Commands;

namespace VendingMachine.Tests.CommandsTests.LoginCommandTests
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
        public void HavingNullAuthenticationService_WhenCallingConstructor_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                LoginCommand loginCommand = new LoginCommand(null, useCaseFactory.Object);
            });
        }

        [TestMethod]
        public void HavingNullLoginView_WhenCallingConstructor_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                LoginCommand loginCommand = new LoginCommand(authenticationService.Object, null);
            });
        }

        [TestMethod]
        public void WhenInitializingTheUseCase_NameIsCorrect()
        {
            LoginCommand loginCommand = new LoginCommand(authenticationService.Object, useCaseFactory.Object);

            Assert.AreEqual("login", loginCommand.Name);
        }

        [TestMethod]
        public void WhenInitializingTheUseCase_DescriptionHasValue()
        {
            LoginCommand loginCommand = new LoginCommand(authenticationService.Object, useCaseFactory.Object);
            Assert.AreEqual("login", loginCommand.Name);

            Assert.IsNotNull(loginCommand.Description);
        }
    }
}