using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nagarro.VendingMachine.DataAccess;
using Nagarro.VendingMachine.PresentationLayer;
using Nagarro.VendingMachine.UseCases;
using VendingMachine.Business.Logging;

namespace VendingMachine.Tests.UseCasesTests.LookUseCaseTests
{
    [TestClass]
    public class ExecuteTests
    {
        [TestMethod]
        public void HavingALookOutUseCaseInstance_WhenExecuted_ThenProductsAreDisplayed()
        {
            Mock<IShelfView> shelfView = new Mock<IShelfView>();
            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            Mock<ILogger<LookUseCase>> logger = new Mock<ILogger<LookUseCase>>();
            LookUseCase lookUseCase = new LookUseCase(shelfView.Object, productRepository.Object, logger.Object);

            lookUseCase.Execute();

            shelfView.Verify(x => x.DisplayProducts(productRepository.Object.GetAll()), Times.Once());
        }
    }
}