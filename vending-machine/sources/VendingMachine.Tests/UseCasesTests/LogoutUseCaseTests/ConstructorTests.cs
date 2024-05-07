using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nagarro.VendingMachine.Authentication;
using Nagarro.VendingMachine.UseCases;
using VendingMachine.Business.Logging;

namespace VendingMachine.Tests.UseCasesTests.LogoutUseCaseTests
{
    [TestClass]
    public class ConstructorTests
    {
        private readonly Mock<IAuthenticationService> authenticationService;
        private readonly Mock<ILogger<LogoutUseCase>> logger;

        public ConstructorTests()
        {
            authenticationService = new Mock<IAuthenticationService>();
            logger = new Mock<ILogger<LogoutUseCase>>();
        }

        [TestMethod]
        public void HavingANullAuthenticationService_WhenInitializingTheUseCase_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new LogoutUseCase(null, logger.Object);
            });
        }
    }
}