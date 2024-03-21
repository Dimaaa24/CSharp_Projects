namespace Nagarro.VendingMachine.Presentation
{
    internal class CommandSelectorControl : DisplayBase
    {
        public IEnumerable<IUseCase> UseCases { get; set; }

        public IUseCase Display()
        {
            DisplayUseCases();
            return SelectUseCase();
        }

        private void DisplayUseCases()
        {
            DisplayLine(new string('-', 50), ConsoleColor.Magenta);
            DisplayLine("\t      ~  Commands Menu  ~", ConsoleColor.Magenta);
            DisplayLine(new string('-', 50), ConsoleColor.Magenta);

            foreach (IUseCase useCase in UseCases)
                DisplayUseCase(useCase);
        }

        private void DisplayUseCase(IUseCase useCase)
        {
            Display(useCase.Name, ConsoleColor.Magenta);
            DisplayLine($"- {useCase.Description}", ConsoleColor.DarkMagenta);
        }

        private IUseCase SelectUseCase()
        {
            while (true)
            {
                string rawValue = ReadCommandName();
                IUseCase selectedUseCase = FindUseCase(rawValue);

                if (selectedUseCase != null)
                    return selectedUseCase;

                DisplayLine("Invalid command. Please try again.", ConsoleColor.Red);
            }
        }

        private IUseCase FindUseCase(string rawValue)
        {
            IUseCase selectedUseCase = null;

            foreach (IUseCase x in UseCases)
            {
                if (x.Name == rawValue)
                {
                    selectedUseCase = x;
                    break;
                }
            }

            return selectedUseCase;
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