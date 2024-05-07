using Nagarro.VendingMachine.DataAccess;
using Nagarro.VendingMachine.PresentationLayer;
using VendingMachine.Business.Logging;

namespace Nagarro.VendingMachine.UseCases
{
    internal sealed class LookUseCase : IUseCase
    {
        private readonly IShelfView shelfView;
        private readonly IProductRepository productRepository;
        private readonly ILogger<LookUseCase> logger;

        public LookUseCase(IShelfView shelfView, IProductRepository productRepository, ILogger<LookUseCase> logger)
        {
            this.shelfView = shelfView ?? throw new ArgumentNullException(nameof(shelfView));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Execute()
        {
            logger.Info("Look usecase initialized-products have been displayed.");
            shelfView.DisplayHeader();
            shelfView.DisplayProducts(productRepository.GetAll());
        }
    }
}