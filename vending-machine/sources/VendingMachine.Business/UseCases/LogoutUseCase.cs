using Nagarro.VendingMachine.Authentication;
using VendingMachine.Business.Logging;

namespace Nagarro.VendingMachine.UseCases
{
    internal class LogoutUseCase : IUseCase
    {
        private readonly IAuthenticationService authenticationService;
        private readonly ILogger<LogoutUseCase> logger;

        public LogoutUseCase(IAuthenticationService authenticationService, ILogger<LogoutUseCase> logger)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Execute()
        {
            logger.Info("Logout use case initialized.");
            authenticationService.Logout();
        }
    }
}