using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nagarro.VendingMachine.Authentication;

namespace VendingMachine.Tests.AuthenticationServiceTests
{
    [TestClass]
    public class ConstructorTests
    {
        [TestMethod]
        public void HavingAuthenticationServiceInstance_ThenUserIsNotAuthenticated()
        {
            AuthenticationService authenticationService = new AuthenticationService();

            Assert.IsFalse(authenticationService.IsUserAuthenticated);
        }
    }
}