using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nagarro.VendingMachine.Authentication;
using VendingMachine.Business.Logging;

namespace VendingMachine.Tests.AuthenticationServiceTests
{
    [TestClass]
    public class LogoutTests
    {
        private const string CorrectPassword = "test";
        private readonly AuthenticationService authenticationService;
        private readonly Mock<ILogger<AuthenticationService>> logger;

        private LogoutTests()
        {
            logger = new Mock<ILogger<AuthenticationService>>();
            authenticationService = new AuthenticationService(logger.Object);
        }

        [TestMethod]
        public void HavingAnAuthenticatedUser_WhenLogout_ThenUserIsNotAuthenticated()
        {
            authenticationService.Login(CorrectPassword);

            authenticationService.Logout();

            Assert.IsFalse(authenticationService.IsUserAuthenticated);
        }

        [TestMethod]
        public void HavingAnUnAuthenticatedUser_WhenLogout_ThenUserIsNotAuthenticated()
        {
            authenticationService.Logout();

            Assert.IsFalse(authenticationService.IsUserAuthenticated);
        }
    }
}