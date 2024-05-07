using Nagarro.VendingMachine.DataAccess;
using Nagarro.VendingMachine.Exceptions;
using Nagarro.VendingMachine.Models;
using Nagarro.VendingMachine.Payment;
using Nagarro.VendingMachine.PresentationLayer;
using VendingMachine.Business.Logging;
using VendingMachine.Business.Models;

namespace Nagarro.VendingMachine.UseCases
{
    internal class BuyUseCase : IUseCase
    {
        private readonly IBuyView buyView;
        private readonly IProductRepository productRepository;
        private readonly ISaleRepository saleRepository;
        private readonly IPaymentService paymentService;
        private readonly ILogger<BuyUseCase> logger;

        public BuyUseCase(IBuyView buyView, IProductRepository productRepository, IPaymentService paymentService, ISaleRepository saleRepository, ILogger<BuyUseCase> logger)
        {
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.paymentService = paymentService ?? throw new ArgumentNullException(nameof(paymentService));
            this.saleRepository = saleRepository ?? throw new ArgumentNullException(nameof(saleRepository));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Execute()
        {
            logger.Info("Buy use case initialized.");
            int productId = 0;
            Product product = null;

            while (product == null)
            {
                productId = buyView.RequestId();
                product = productRepository.GetById(productId);
                if (product == null || productId == -1)
                {
                    logger.Error($"Inputed invalid product ID {productId}.");
                    buyView.InvalidProductId(productId);
                }
            }

            if (product.Quantity == 0)
            {
                logger.Error($"Invalid stock for product {product.Name}.");
                throw new InsufficientStockException(product.Name);
            }

            int confirmPay = buyView.ConfirmPay();

            while (confirmPay == -1)
            {
                buyView.ConfirmPayError();
                confirmPay = buyView.ConfirmPay();
            }

            string paymentType;

            if (confirmPay == 1)
            {
                if (paymentService.Execute(product.Price, out paymentType))
                {
                    logger.Info($"Product {product.Name} succsefully paid {product.Price} and dispensed using {paymentType}.");
                    productRepository.DecrementStock(productId);
                    buyView.DispenseProduct(product.Name);
                    Sale sale = new Sale { ProductName = product.Name, Price = product.Price, PaymentType = paymentType, Date = DateTime.Now };
                    saleRepository.CreateNewSale(sale);
                }
                else
                {
                    logger.Error("Payment failed.");
                }
            }
            else 
            {
                logger.Error("Payment canceled.");
            }
        }
    }
}