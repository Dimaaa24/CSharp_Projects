using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nagarro.VendingMachine.DataAccess;
using Nagarro.VendingMachine.Payment;
using Nagarro.VendingMachine.PresentationLayer;
using Nagarro.VendingMachine.UseCases;
using VendingMachine.Business.Logging;

namespace VendingMachine.Tests.UseCasesTests.LookUseCaseTests
{
    [TestClass]
    public class ConstructorTests
    {
        private readonly Mock<IShelfView> shelfView;
        private readonly Mock<IProductRepository> productRepository;
        private readonly Mock<ILogger<LookUseCase>> logger;

        public ConstructorTests()
        {
            logger = new Mock<ILogger<LookUseCase>>();
            shelfView = new Mock<IShelfView>();
            productRepository = new Mock<IProductRepository>();
        }

        [TestMethod]
        public void HavingNullProductRepository_WhenCallingConstructor_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                LookUseCase lookUseCase = new LookUseCase(shelfView.Object, null, logger.Object);
            });
        }

        [TestMethod]
        public void HavingNullShelfView_WhenCallingConstructor_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                LookUseCase lookUseCase = new LookUseCase(null, productRepository.Object, logger.Object);
            });
        }
    }
}