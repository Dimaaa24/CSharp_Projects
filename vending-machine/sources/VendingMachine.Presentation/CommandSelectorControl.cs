using VendingMachine.Presentation.Commands;

namespace Nagarro.VendingMachine.Presentation
{
    internal class CommandSelectorControl : DisplayBase
    {
        public IEnumerable<ICommands> commandsList { get; set; }

        public ICommands Display()
        {
            DisplayUseCases();
            return SelectUseCase();
        }

        private void DisplayUseCases()
        {
            DisplayLine(new string('-', 50), ConsoleColor.Magenta);
            DisplayLine("\t      ~  Commands Menu  ~", ConsoleColor.Magenta);
            DisplayLine(new string('-', 50), ConsoleColor.Magenta);

            foreach (ICommands command in commandsList)
                DisplayCommand(command);
        }

        private void DisplayCommand(ICommands command)
        {
            Display(command.Name, ConsoleColor.Magenta);
            DisplayLine($"- {command.Description}", ConsoleColor.DarkMagenta);
        }

        private ICommands SelectUseCase()
        {
            while (true)
            {
                string rawValue = ReadCommandName();
                ICommands selectedCommand = FindUseCase(rawValue);

                if (selectedCommand != null)
                    return selectedCommand;

                DisplayLine("Invalid command. Please try again.", ConsoleColor.Red);
            }
        }

        private ICommands FindUseCase(string rawValue)
        {
            ICommands selectedCommand = null;

            foreach (ICommands command in commandsList)
            {
                if (command.Name == rawValue)
                {
                    selectedCommand = command;
                    break;
                }
            }

            return selectedCommand;
        }

        private string ReadCommandName()
        {
            Console.WriteLine();
            Display("Choose command: ", ConsoleColor.Magenta);
            string rawValue = Console.ReadLine();
            Console.WriteLine();

            return rawValue;
        }
    }
}