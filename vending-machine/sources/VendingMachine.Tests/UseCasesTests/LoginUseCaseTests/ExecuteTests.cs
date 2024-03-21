using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nagarro.VendingMachine.Authentication;
using Nagarro.VendingMachine.PresentationLayer;
using Nagarro.VendingMachine.UseCases;

namespace VendingMachine.Tests.UseCasesTests.LoginUseCaseTests
{
    [TestClass]
    public class ExecuteTests
    {
        private readonly Mock<IAuthenticationService> authenticationService;
        private readonly Mock<ILoginView> loginView;
        private readonly LoginUseCase loginUseCase;

        public ExecuteTests()
        {
            authenticationService = new Mock<IAuthenticationService>();
            loginView = new Mock<ILoginView>();

            loginUseCase = new LoginUseCase(authenticationService.Object, loginView.Object);
        }

        [TestMethod]
        public void HavingALoginUseCaseInstance_WhenExecuted_TheUserIsAskedToInputPassword()
        {
            loginUseCase.Execute();

            loginView.Verify(x => x.AskForPassword(), Times.Once());
        }

        [TestMethod]
        public void HavingALoginUseCaseInstance_WhenExecuted_TheUserIsAuthenticated()
        {
            loginView.Setup(x => x.AskForPassword()).Returns("test");

            loginUseCase.Execute();

            authenticationService.Verify(x => x.Login("test"), Times.Once());
        }
    }
}