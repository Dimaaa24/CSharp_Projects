using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nagarro.VendingMachine.Authentication;
using VendingMachine.Presentation;
using VendingMachine.Presentation.Commands;

namespace VendingMachine.Tests.CommandsTests.BuyCommandTests
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
        public void WhenInitializingTheCommand_NameIsCorect()
        {
            BuyCommand buyCommand = new BuyCommand(authenticationService.Object, useCaseFactory.Object);

            Assert.AreEqual("buy", buyCommand.Name);
        }

        [TestMethod]
        public void WhenInitializingTheCommand_DescriptionHasValue()
        {
            BuyCommand buyCommand = new BuyCommand(authenticationService.Object, useCaseFactory.Object);

            Assert.IsNotNull(buyCommand.Description);
        }

        [TestMethod]
        public void HavingNullAuthenticationService_WhenCallingConstructor_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                BuyCommand loginCommand = new BuyCommand(null, useCaseFactory.Object);
            });
        }

        [TestMethod]
        public void HavingNullLoginView_WhenCallingConstructor_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                BuyCommand loginCommand = new BuyCommand(authenticationService.Object, null);
            });
        }
    }
}