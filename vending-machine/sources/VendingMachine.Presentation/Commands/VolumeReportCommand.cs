using Nagarro.VendingMachine.Authentication;
using VendingMachine.Business.UseCases;

namespace VendingMachine.Presentation.Commands
{
    internal class VolumeReportCommand : ICommands
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IUseCaseFactory useCaseFactory;
        public string Name => "volume report";

        public string Description => "Generate volume reports.";

        public bool CanExecute => authenticationService.IsUserAuthenticated;

        public VolumeReportCommand(IAuthenticationService authenticationService, IUseCaseFactory useCaseFactory)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
        }

        public void Execute()
        {
            useCaseFactory.Create<VolumeReportUseCase>().Execute();
        }
    }
}
