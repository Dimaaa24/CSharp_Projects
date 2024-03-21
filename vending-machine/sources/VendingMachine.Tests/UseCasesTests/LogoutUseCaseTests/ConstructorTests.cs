using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nagarro.VendingMachine.Authentication;
using Nagarro.VendingMachine.UseCases;

namespace VendingMachine.Tests.UseCasesTests.LogoutUseCaseTests
{
    [TestClass]
    public class ConstructorTests
    {
        private readonly Mock<IAuthenticationService> authenticationService;

        public ConstructorTests()
        {
            authenticationService = new Mock<IAuthenticationService>();
        }

        [TestMethod]
        public void HavingANullAuthenticationService_WhenInitializingTheUseCase_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new LogoutUseCase(null);
            });
        }

        [TestMethod]
        public void WhenInitializingTheUseCase_NameIsCorrect()
        {
            LogoutUseCase logoutUseCase = new LogoutUseCase(authenticationService.Object);

            Assert.AreEqual("logout", logoutUseCase.Name);
        }

        [TestMethod]
        public void WhenInitializingTheUseCase_DescriptionHasValue()
        {
            LogoutUseCase logoutUseCase = new LogoutUseCase(authenticationService.Object);

            Assert.IsNotNull(logoutUseCase.Description);
        }
    }
}