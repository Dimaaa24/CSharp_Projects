using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nagarro.VendingMachine.Authentication;

namespace VendingMachine.Tests.AuthenticationServiceTests
{
    [TestClass]
    public class LogoutTests
    {
        private const string CorrectPassword = "supercalifragilisticexpialidocious";

        [TestMethod]
        public void HavingAnAuthenticatedUser_WhenLogout_ThenUserIsNotAuthenticated()
        {
            AuthenticationService authenticationService = new AuthenticationService();
            authenticationService.Login(CorrectPassword);

            authenticationService.Logout();

            Assert.IsFalse(authenticationService.IsUserAuthenticated);
        }

        [TestMethod]
        public void HavingAnUnAuthenticatedUser_WhenLogout_ThenUserIsNotAuthenticated()
        {
            AuthenticationService authenticationService = new AuthenticationService();

            authenticationService.Logout();

            Assert.IsFalse(authenticationService.IsUserAuthenticated);
        }
    }
}