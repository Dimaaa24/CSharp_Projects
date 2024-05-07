using Nagarro.VendingMachine.Authentication;
using VendingMachine.Business.UseCases;

namespace VendingMachine.Presentation.Commands
{
    internal class StockReportCommand : ICommands
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IUseCaseFactory useCaseFactory;
        public string Name => "stock report";

        public string Description => "Generate stocks reports.";

        public bool CanExecute => authenticationService.IsUserAuthenticated;

        public StockReportCommand(IAuthenticationService authenticationService, IUseCaseFactory useCaseFactory)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
        }

        public void Execute()
        {
            useCaseFactory.Create<StockReportUseCase>().Execute();
        }
    }
}
