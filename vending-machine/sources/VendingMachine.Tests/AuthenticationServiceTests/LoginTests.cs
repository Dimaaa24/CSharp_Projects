using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nagarro.VendingMachine.Authentication;
using Nagarro.VendingMachine.Exceptions;
using Nagarro.VendingMachine.Payment;
using VendingMachine.Business.Logging;

namespace VendingMachine.Tests.AuthenticationServiceTests
{
    [TestClass]
    public class LoginTests
    {
        private const string CorrectPassword = "test";
        private readonly Mock<ILogger<AuthenticationService>> logger;
        private readonly AuthenticationService authenticationService;

        public LoginTests() 
        {
            logger = new Mock<ILogger<AuthenticationService>>();
            authenticationService = new AuthenticationService(logger.Object);

        }

        [TestMethod]
        public void HavingAnAuthenticationService_WhenLoginWithCorrectPassword_ThenUserIsAuthenticated()
        {
            authenticationService.Login(CorrectPassword);

            Assert.IsTrue(authenticationService.IsUserAuthenticated);
        }

        [TestMethod]
        public void HavingAnAuthenticationService_WhenLoginWithIncorrectPassword_ThenThrowsException()
        {
            Assert.ThrowsException<InvalidPasswordException>(() =>
            {
                authenticationService.Login("incorrect");
            });
        }

        [TestMethod]
        public void HavingAnAuthenticationService_WhenLoginWithIncorrectPassword_ThenUserIsNotAuthenticated()
        {
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
            authenticationService.Login(CorrectPassword);
            authenticationService.Login(CorrectPassword);

            Assert.IsTrue(authenticationService.IsUserAuthenticated);
        }
    }
}