using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VendingMachine.Presentation;
using VendingMachine.Presentation.Commands;

namespace VendingMachine.Tests.CommandsTests.LookCommandTests
{
    [TestClass]
    public class ConstructorTests
    {
        private readonly Mock<IUseCaseFactory> useCaseFactory;

        public ConstructorTests()
        {
            useCaseFactory = new Mock<IUseCaseFactory>();
        }

        [TestMethod]
        public void WhenInitializingTheCommand_NameIsCorrect()
        {
            LookCommand lookCommand = new LookCommand(useCaseFactory.Object);

            Assert.AreEqual("look", lookCommand.Name);
        }

        [TestMethod]
        public void WhenInitializingTheCommand_DescriptionHasValue()
        {
            LookCommand lookCommand = new LookCommand(useCaseFactory.Object);

            Assert.IsNotNull(lookCommand.Description);
        }

        [TestMethod]
        public void HavingNullUseCaseFactory_WhenCallingConstructor_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                LookCommand lookCommand = new LookCommand(null);
            });
        }
    }
}