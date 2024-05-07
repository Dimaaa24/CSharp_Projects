using Nagarro.VendingMachine.Exceptions;
using VendingMachine.Business.Logging;

namespace Nagarro.VendingMachine.Authentication
{
    internal class AuthenticationService : IAuthenticationService
    {
        private readonly ILogger<AuthenticationService> logger;
        public AuthenticationService(ILogger<AuthenticationService> logger) 
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public bool IsUserAuthenticated { get; private set; }

        public void Login(string password)
        {
            if (password == "test")
            {
                logger.Info("User succesfully authenticated");
                IsUserAuthenticated = true;
            }
            else
            {
                throw new InvalidPasswordException();
            }
        }

        public void Logout()
        {
            logger.Info("User succesfully logged out");
            IsUserAuthenticated = false;
        }
    }
}