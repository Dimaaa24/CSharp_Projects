using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nagarro.VendingMachine.Authentication;
using Nagarro.VendingMachine.DataAccess;
using Nagarro.VendingMachine.Exceptions;
using Nagarro.VendingMachine.Models;
using Nagarro.VendingMachine.Payment;
using Nagarro.VendingMachine.PresentationLayer;
using Nagarro.VendingMachine.UseCases;

namespace VendingMachine.Tests.UseCases.BuyUseCaseTests
{
    [TestClass]
    public class ExecuteTests
    {
        private readonly Mock<IAuthenticationService> authenticationService;
        private readonly Mock<IProductRepository> productRepository;
        private readonly Mock<IBuyView> buyView;
        private readonly Mock<IPaymentService> paymentService;
        private readonly BuyUseCase buyUseCase;

        public ExecuteTests()
        {
            authenticationService = new Mock<IAuthenticationService>();
            productRepository = new Mock<IProductRepository>();
            buyView = new Mock<IBuyView>();
            paymentService = new Mock<IPaymentService>();

            buyUseCase = new BuyUseCase(authenticationService.Object, buyView.Object, productRepository.Object, paymentService.Object);
        }

        [TestMethod]
        public void HavingABuyUseCaseInstance_WhenExecuted_TheUserIsAskedToInputId()
        {
            productRepository
                .Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Product { Quantity = 1, Price = 10 });
            buyView
                .Setup(x => x.AskForPaymentMethod(It.IsAny<List<PaymentMethod>>()))
                .Returns(2);
            buyView
                .Setup(x => x.ConfirmPay())
                .Returns(true);

            buyUseCase.Execute();

            buyView.Verify(x => x.RequestId(), Times.Once());
        }

        [TestMethod]
        public void HavingABuyUseCaseInstance_WhenExecuted_ThenItRequestsFromProductRepositoryTheProduct()
        {
            productRepository
                .Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Product { Quantity = 1, Price = 10 });
            buyView
                .Setup(x => x.AskForPaymentMethod(It.IsAny<List<PaymentMethod>>()))
                .Returns(1);
            buyView
                .Setup(x => x.ConfirmPay())
                .Returns(true);
            buyView
                .Setup(x => x.AskForPaymentMethod(It.IsAny<List<PaymentMethod>>()))
                .Returns(2);

            buyUseCase.Execute();

            productRepository.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void HavingABuyUseCaseInstance_WhenProductWithInsufficientQuantity_ThenThrowException()
        {
            productRepository
                .Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Product { Quantity = 0 });

            Assert.ThrowsException<InsufficientStockException>(() => buyUseCase.Execute());
            Assert.AreEqual(0, productRepository.Object.GetById(1).Quantity);
        }

        [TestMethod]
        public void HavingABuyUseCase_WhenProductIsInStock_ThenPaymentServiceIsExecuted()
        {
            buyView
                .Setup(x => x.RequestId())
                .Returns(1);
            productRepository
                .Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Product { Quantity = 1, Price = 10 });
            buyView
                .Setup(x => x.ConfirmPay())
                .Returns(true);
            buyView
                .Setup(x => x.AskForPaymentMethod(It.IsAny<List<PaymentMethod>>()))
                .Returns(2);

            buyUseCase.Execute();

            paymentService.Verify(x => x.Execute(It.IsAny<decimal>()), Times.Once());
        }

        [TestMethod]
        public void HavingABuyUseCaseInstance_WhenConfirmPayIsTrue_ThenDecrementStockIsCalled()
        {
            buyView
                .Setup(x => x.RequestId())
                .Returns(1);
            productRepository
                .Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Product { Quantity = 1, Price = 10 });
            buyView
                .Setup(x => x.ConfirmPay())
                .Returns(true);
            paymentService
                .Setup(x => x.Execute(It.IsAny<decimal>()))
                .Returns(true);

            buyUseCase.Execute();

            productRepository.Verify(x => x.DecrementStock(1), Times.Once());
        }

        [TestMethod]
        public void HavingABuyUseCaseInstance_WhenConfirmPayIsTrue_ThenProductIsDispensed()
        {
            buyView
               .Setup(x => x.RequestId())
               .Returns(1);
            productRepository
                .Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Product { Name = "test", Quantity = 1, Price = 10 });
            buyView
                .Setup(x => x.ConfirmPay())
                .Returns(true);
            paymentService
                .Setup(x => x.Execute(It.IsAny<decimal>()))
                .Returns(true);

            buyUseCase.Execute();

            buyView.Verify(x => x.DispenseProduct("test"), Times.Once());
        }
    }
}