using Nagarro.VendingMachine.Authentication;
using Nagarro.VendingMachine.DataAccess;
using Nagarro.VendingMachine.Exceptions;
using Nagarro.VendingMachine.Models;
using Nagarro.VendingMachine.Payment;
using Nagarro.VendingMachine.PresentationLayer;

namespace Nagarro.VendingMachine.UseCases
{
    internal class BuyUseCase : IUseCase
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IBuyView buyView;
        private readonly IProductRepository productRepository;
        private readonly IPaymentService paymentService;

        public string Name => "buy";

        public string Description => "Buy products.";

        public bool CanExecute => !authenticationService.IsUserAuthenticated;

        public BuyUseCase(IAuthenticationService authenticationService, IBuyView buyView, IProductRepository productRepository, IPaymentService paymentService)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.paymentService = paymentService ?? throw new ArgumentNullException(nameof(paymentService));
        }

        public void Execute()
        {
            int productId = 0;
            Product product = null;

            while (product == null)
            {
                productId = buyView.RequestId();
                product = productRepository.GetById(productId);
                if (product == null || productId == -1)
                {
                    buyView.InvalidProductId(productId);
                }
            }

            if (product.Quantity == 0)
            {
                throw new InsufficientStockException(product.Name);
            }

            int confirmPay = buyView.ConfirmPay();

            while(confirmPay == -1)
            {
                buyView.ConfirmPayError();
                confirmPay = buyView.ConfirmPay();
            }

            if (confirmPay == 1 && paymentService.Execute(product.Price))
            {
                productRepository.DecrementStock(productId);
                buyView.DispenseProduct(product.Name);
            }
        }
    }
}