using Nagarro.VendingMachine.DataAccess;
using Nagarro.VendingMachine.PresentationLayer;

namespace Nagarro.VendingMachine.UseCases
{
    internal sealed class LookUseCase : IUseCase
    {
        private readonly IShelfView shelfView;
        private readonly IProductRepository productRepository;
        public string Name => "look";

        public string Description => "Look at the existing products!";

        public bool CanExecute => true;

        public LookUseCase(IShelfView shelfView, IProductRepository productRepository)
        {
            this.shelfView = shelfView ?? throw new ArgumentNullException(nameof(shelfView));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public void Execute()
        {
            shelfView.DisplayHeader();
            shelfView.DisplayProducts(this.productRepository.GetAll());
        }
    }
}