using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VendingMachine.Presentation;
using VendingMachine.Presentation.Commands;

namespace VendingMachine.Tests.CommandsTests.LookCommandTests
{
    [TestClass]
    public class CanExecuteTests
    {
        private readonly Mock<IUseCaseFactory> useCaseFactory;

        public CanExecuteTests()
        {
            useCaseFactory = new Mock<IUseCaseFactory>();
        }

        [TestMethod]
        public void HavingALoginCommandInstance_ThenCanExecuteIsAlwaysTrue()
        {
            LookCommand lookCommand = new LookCommand(useCaseFactory.Object);

            Assert.AreEqual(lookCommand.CanExecute, true);
        }
    }
}