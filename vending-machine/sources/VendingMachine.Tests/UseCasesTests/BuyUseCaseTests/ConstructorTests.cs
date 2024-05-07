using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nagarro.VendingMachine.DataAccess;
using Nagarro.VendingMachine.Payment;
using Nagarro.VendingMachine.PresentationLayer;
using Nagarro.VendingMachine.UseCases;
using VendingMachine.Business.Logging;

namespace VendingMachine.Tests.UseCasesTests.BuyUseCaseTests
{
    [TestClass]
    public class ConstructorTests
    {
        private readonly Mock<IProductRepository> productRepository;
        private readonly Mock<ISaleRepository> saleRepository;
        private readonly Mock<IPaymentService> paymentService;
        private readonly Mock<IBuyView> buyView;
        private readonly Mock<ILogger<BuyUseCase>> logger;

        public ConstructorTests()
        {
            productRepository = new Mock<IProductRepository>();
            saleRepository = new Mock<ISaleRepository>();
            paymentService = new Mock<IPaymentService>();
            buyView = new Mock<IBuyView>();
            logger = new Mock<ILogger<BuyUseCase>>();
        }

        [TestMethod]
        public void HavingANullBuyView_WhenCallingConstructor_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                BuyUseCase buyUseCase = new BuyUseCase(null, productRepository.Object, paymentService.Object, saleRepository.Object, logger.Object);
            });
        }

        [TestMethod]
        public void HavingANullProductRepository_WhenCallingConstructor_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                BuyUseCase buyUseCase = new BuyUseCase(buyView.Object, null, paymentService.Object, saleRepository.Object, logger.Object);
            });
        }

        [TestMethod]
        public void HavingANullPaymentService_WhenCallingConstructor_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                BuyUseCase buyUseCase = new BuyUseCase(buyView.Object, productRepository.Object, null, saleRepository.Object, logger.Object);
            });
        }

        [TestMethod]
        public void HavingANullSaleRepository_WhenCallingConstructor_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                BuyUseCase buyUseCase = new BuyUseCase(buyView.Object, productRepository.Object, paymentService.Object, null, logger.Object);
            });
        }
    }
}