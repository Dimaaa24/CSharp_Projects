using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nagarro.VendingMachine.Authentication;
using VendingMachine.Business.Logging;

namespace VendingMachine.Tests.AuthenticationServiceTests
{
    [TestClass]
    public class ConstructorTests
    {
        [TestMethod]
        public void HavingAuthenticationServiceInstance_ThenUserIsNotAuthenticated()
        {
            Mock<ILogger<AuthenticationService>> logger = new Mock<ILogger<AuthenticationService>>();
            AuthenticationService authenticationService = new AuthenticationService(logger.Object);

            Assert.IsFalse(authenticationService.IsUserAuthenticated);
        }
    }
}