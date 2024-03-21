using Nagarro.VendingMachine.PresentationLayer;

namespace Nagarro.VendingMachine.Presentation
{
    internal class MainView : DisplayBase, IMainView
    {
        private ApplicationHeaderControl applicationHeaderControl = new ApplicationHeaderControl();

        public void DisplayApplicationHeader()
        {
            ChangeBackgroundAndForeground(ConsoleColor.White, ConsoleColor.Magenta);
            applicationHeaderControl.Display();
        }

        public IUseCase ChooseCommand(IEnumerable<IUseCase> useCases)
        {
            CommandSelectorControl commandSelectorControl = new CommandSelectorControl
            {
                UseCases = useCases
            };
            return commandSelectorControl.Display();
        }
    }
}