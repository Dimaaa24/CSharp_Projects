using Nagarro.VendingMachine.UseCases;

namespace VendingMachine.Presentation.Commands
{
    internal class LookCommand : ICommands
    {
        private readonly IUseCaseFactory useCaseFactory;
        public string Name => "look";

        public string Description => "Look at the existing products!";

        public bool CanExecute => true;

        public LookCommand(IUseCaseFactory useCaseFactory)
        {
            this.useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
        }

        public void Execute()
        {
            useCaseFactory.Create<LookUseCase>().Execute();
        }
    }
}