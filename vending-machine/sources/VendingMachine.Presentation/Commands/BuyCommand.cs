using Nagarro.VendingMachine.Authentication;
using Nagarro.VendingMachine.UseCases;

namespace VendingMachine.Presentation.Commands
{
    internal class BuyCommand : ICommands
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IUseCaseFactory useCaseFactory;

        public string Name => "buy";

        public string Description => "Buy products.";

        public bool CanExecute => !authenticationService.IsUserAuthenticated;

        public BuyCommand(IAuthenticationService authenticationService, IUseCaseFactory useCaseFactory)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
        }

        public void Execute()
        {
            useCaseFactory.Create<BuyUseCase>().Execute();
        }
    }
}