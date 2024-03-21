using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nagarro.VendingMachine.Authentication;
using Nagarro.VendingMachine.Exceptions;

namespace VendingMachine.Tests.AuthenticationServiceTests
{
    [TestClass]
    public class LoginTests
    {
        private const string CorrectPassword = "supercalifragilisticexpialidocious";

        [TestMethod]
        public void HavingAnAuthenticationService_WhenLoginWithCorrectPassword_ThenUserIsAuthenticated()
        {
            AuthenticationService authenticationService = new AuthenticationService();

            authenticationService.Login(CorrectPassword);

            Assert.IsTrue(authenticationService.IsUserAuthenticated);
        }

        [TestMethod]
        public void HavingAnAuthenticationService_WhenLoginWithIncorrectPassword_ThenThrowsException()
        {
            AuthenticationService authenticationService = new AuthenticationService();

            Assert.ThrowsException<InvalidPasswordException>(() =>
            {
                authenticationService.Login("incorrect");
            });
        }

        [TestMethod]
        public void HavingAnAuthenticationService_WhenLoginWithIncorrectPassword_ThenUserIsNotAuthenticated()
        {
            AuthenticationService authenticationService = new AuthenticationService();

            try
            {
                authenticationService.Login("incorrect");
            }
            catch
            {
            }

            Assert.IsFalse(authenticationService.IsUserAuthenticated);
        }

        [TestMethod]
        public void HavingAnAuthenticationService_WhenTryToLoginTwiceWithCorrectPassword_ThenUserIsAuthenticated()
        {
            AuthenticationService authenticationService = new AuthenticationService();

            authenticationService.Login(CorrectPassword);
            authenticationService.Login(CorrectPassword);

            Assert.IsTrue(authenticationService.IsUserAuthenticated);
        }
    }
}