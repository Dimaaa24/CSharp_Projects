using VendingMachine.Presentation;
using VendingMachine.Presentation.Commands;

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

        public ICommands ChooseCommand(IEnumerable<ICommands> commands)
        {
            CommandSelectorControl commandSelectorControl = new CommandSelectorControl
            {
                commandsList = commands
            };
            return commandSelectorControl.Display();
        }
    }
}