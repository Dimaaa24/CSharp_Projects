using Nagarro.VendingMachine.PresentationLayer;

namespace Nagarro.VendingMachine.Presentation
{
    internal class LoginView : DisplayBase, ILoginView
    {
        public string AskForPassword()
        {
            DisplayLine(new string('=', 40), ConsoleColor.Magenta);
            DisplayLine("Type the admin password: ", ConsoleColor.Magenta);
            DisplayLine(new string('=', 40), ConsoleColor.Magenta);
            return Console.ReadLine();
        }
    }
}