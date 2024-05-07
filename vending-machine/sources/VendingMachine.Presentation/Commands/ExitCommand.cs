using VendingMachine.Business.Logging;

namespace VendingMachine.Presentation.Commands
{
    internal class ExitCommand : ICommands
    {
        private readonly ILogger<ExitCommand> logger;

        public string Name => "exit";

        public string Description => "Exit application.";

        public bool CanExecute => true;

        public ExitCommand(ILogger<ExitCommand> logger)
        {
            this.logger = logger;
        }

        public void Execute()
        {
            logger.Info("VendingMachine application ended.");
            Environment.Exit(0);
        }
    }
}
