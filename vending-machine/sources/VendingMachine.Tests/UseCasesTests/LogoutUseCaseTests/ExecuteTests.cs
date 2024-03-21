using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nagarro.VendingMachine.Authentication;
using Nagarro.VendingMachine.UseCases;

namespace VendingMachine.Tests.UseCasesTests.LogoutUseCaseTests
{
    [TestClass]
    public class ExecuteTests
    {
        [TestMethod]
        public void HavingALogOutUseCaseInstance_WhenExecuted_ThenUserIsAuthenticated()
        {
            Mock<IAuthenticationService> authenticationService = new Mock<IAuthenticationService>();
            LogoutUseCase logoutUseCase = new LogoutUseCase(authenticationService.Object);

            logoutUseCase.Execute();

            authenticationService.Verify(x => x.Logout(), Times.Once());
        }
    }
}