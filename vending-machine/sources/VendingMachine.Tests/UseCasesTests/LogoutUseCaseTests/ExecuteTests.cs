using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nagarro.VendingMachine.Authentication;
using Nagarro.VendingMachine.UseCases;
using VendingMachine.Business.Logging;

namespace VendingMachine.Tests.UseCasesTests.LogoutUseCaseTests
{
    [TestClass]
    public class ExecuteTests
    {
        [TestMethod]
        public void HavingALogOutUseCaseInstance_WhenExecuted_ThenUserIsAuthenticated()
        {
            Mock<IAuthenticationService> authenticationService = new Mock<IAuthenticationService>();
            Mock<ILogger<LogoutUseCase>> logger = new Mock<ILogger<LogoutUseCase>>(); 

            LogoutUseCase logoutUseCase = new LogoutUseCase(authenticationService.Object, logger.Object);

            logoutUseCase.Execute();

            authenticationService.Verify(x => x.Logout(), Times.Once());
        }
    }
}