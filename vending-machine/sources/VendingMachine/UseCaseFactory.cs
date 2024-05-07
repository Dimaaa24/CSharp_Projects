using Autofac;
using VendingMachine.Presentation;

namespace VendingMachine
{
    public class UseCaseFactory : IUseCaseFactory
    {
        private readonly IComponentContext componentContext;

        public UseCaseFactory(IComponentContext componentContext)
        {
            this.componentContext = componentContext;
        }

        public IUseCase Create<IUseCase>()
        {
            return componentContext.Resolve<IUseCase>();
        }
    }
}