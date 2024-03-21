using Nagarro.VendingMachine.PresentationLayer;

namespace Nagarro.VendingMachine.Presentation
{
    internal class CardPaymentView : DisplayBase, ICardPaymentView
    {
        public string AskForCardNumber()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("~ Input a card number: ");

            string cardNumber = Console.ReadLine();

            return cardNumber;
        }

        public int CancelCardPayment()
        {
            DisplayLine(new string('-', 80), ConsoleColor.Green);
            Display(new string(' ', 25), ConsoleColor.White);
            DisplayLine("~ Cancel card payment?[Y] or [N] ~", ConsoleColor.DarkGreen);
            Display(new string('-', 80), ConsoleColor.Green);
            Console.ForegroundColor = ConsoleColor.White;

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Y:
                    return 1;

                case ConsoleKey.N:
                    return 0;

                default:
                    return -1;
            }
        }

        public void InvalidCardNumber()
        {
            Console.WriteLine();
            Display(new string(' ', 30), ConsoleColor.White);
            DisplayLine("~ Invalid card number! ~", ConsoleColor.Red);
        }

        public void CardAccepted()
        {
            Console.WriteLine();
            DisplayLine("Card Accepted!", ConsoleColor.DarkGreen);
        }

        public void CancelCardPaymentError()
        {
            Console.WriteLine();
            DisplayLine($"Invalid option.Try Again!", ConsoleColor.Red);
            Console.WriteLine();
        }
    }
}