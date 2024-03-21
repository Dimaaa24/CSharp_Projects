using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nagarro.VendingMachine.DataAccess;
using Nagarro.VendingMachine.PresentationLayer;
using Nagarro.VendingMachine.UseCases;

namespace VendingMachine.Tests.UseCasesTests.LookUseCaseTests
{
    [TestClass]
    public class ConstructorTests
    {
        private readonly Mock<IShelfView> shelfView;
        private readonly Mock<IProductRepository> productRepository;

        public ConstructorTests()
        {
            shelfView = new Mock<IShelfView>();
            productRepository = new Mock<IProductRepository>();
        }

        [TestMethod]
        public void HavingNullProductRepository_WhenCallingConstructor_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                LookUseCase lookUseCase = new LookUseCase(shelfView.Object, null);
            });
        }

        [TestMethod]
        public void HavingNullShelfView_WhenCallingConstructor_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                LookUseCase lookUseCase = new LookUseCase(null, productRepository.Object);
            });
        }

        [TestMethod]
        public void WhenInitializingTheUseCase_NameIsCorrect()
        {
            LookUseCase lookUseCase = new LookUseCase(shelfView.Object, productRepository.Object);

            Assert.AreEqual("look", lookUseCase.Name);
        }

        [TestMethod]
        public void WhenInitializingTheUseCase_DescriptionHasValue()
        {
            LookUseCase lookUseCase = new LookUseCase(shelfView.Object, productRepository.Object);

            Assert.IsNotNull(lookUseCase.Description);
        }
    }
}