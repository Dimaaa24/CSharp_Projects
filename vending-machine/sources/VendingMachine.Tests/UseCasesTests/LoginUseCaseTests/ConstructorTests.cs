using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nagarro.VendingMachine.Authentication;
using Nagarro.VendingMachine.PresentationLayer;
using Nagarro.VendingMachine.UseCases;

namespace VendingMachine.Tests.UseCasesTests.LoginUseCaseTests
{
    [TestClass]
    public class ConstructorTests
    {
        private readonly Mock<IAuthenticationService> authenticationService;
        private readonly Mock<ILoginView> loginView;

        public ConstructorTests()
        {
            authenticationService = new Mock<IAuthenticationService>();
            loginView = new Mock<ILoginView>();
        }

        [TestMethod]
        public void HavingNullAuthenticationService_WhenCallingConstructor_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                LoginUseCase loginUseCase = new LoginUseCase(null, loginView.Object);
            });
        }

        [TestMethod]
        public void HavingNullLoginView_WhenCallingConstructor_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                LoginUseCase loginUseCase = new LoginUseCase(authenticationService.Object, null);
            });
        }

        [TestMethod]
        public void WhenInitializingTheUseCase_NameIsCorrect()
        {
            LoginUseCase loginUseCase = new LoginUseCase(authenticationService.Object, loginView.Object);

            Assert.AreEqual("login", loginUseCase.Name);
        }

        [TestMethod]
        public void WhenInitializingTheUseCase_DescriptionHasValue()
        {
            LoginUseCase loginUseCase = new LoginUseCase(authenticationService.Object, loginView.Object);

            Assert.IsNotNull(loginUseCase.Description);
        }
    }
}