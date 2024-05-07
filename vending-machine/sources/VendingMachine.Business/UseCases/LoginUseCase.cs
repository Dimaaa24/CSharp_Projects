using Nagarro.VendingMachine.Authentication;
using Nagarro.VendingMachine.PresentationLayer;
using VendingMachine.Business.Logging;

namespace Nagarro.VendingMachine.UseCases
{
    internal class LoginUseCase : IUseCase
    {
        private readonly IAuthenticationService authenticationService;
        private readonly ILoginView loginView;
        private readonly ILogger<LoginUseCase> logger;


        public LoginUseCase(IAuthenticationService authenticationService, ILoginView loginView, ILogger<LoginUseCase> logger)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.loginView = loginView ?? throw new ArgumentNullException(nameof(loginView));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Execute()
        {
            logger.Info("Login use case initialized.");
            string password = loginView.AskForPassword();
            authenticationService.Login(password);
        }
    }
}