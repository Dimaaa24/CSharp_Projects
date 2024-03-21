using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nagarro.VendingMachine.DataAccess;
using Nagarro.VendingMachine.PresentationLayer;
using Nagarro.VendingMachine.UseCases;

namespace VendingMachine.Tests.UseCasesTests.LookUseCaseTests
{
    [TestClass]
    public class CanExecuteTests
    {
        private readonly Mock<IShelfView> shelfView;
        private readonly Mock<IProductRepository> productRepository;

        public CanExecuteTests()
        {
            shelfView = new Mock<IShelfView>();
            productRepository = new Mock<IProductRepository>();
        }

        [TestMethod]
        public void HavingAdminOrNoAdminLoggedIn_CanExecuteIsAlwaysTrue()
        {
            LookUseCase lookUseCase = new LookUseCase(shelfView.Object, productRepository.Object);

            Assert.IsTrue(lookUseCase.CanExecute);
        }
    }
}