using Nagarro.VendingMachine.Payment;
using Nagarro.VendingMachine.PresentationLayer;

namespace Nagarro.VendingMachine.Presentation
{
    internal class BuyView : DisplayBase, IBuyView
    {
        public int RequestId()
        {
            ChangeBackgroundAndForeground(ConsoleColor.White, ConsoleColor.Green);
            DisplayLine(new string('=', 80), ConsoleColor.Green);
            Display(new string(' ', 30), ConsoleColor.White);
            DisplayLine("~  Buy Item  ~", ConsoleColor.Green);
            DisplayLine(new string('=', 80), ConsoleColor.Green);
            Display("Input an item ID:", ConsoleColor.Green);

            string consoleId = Console.ReadLine();
            for (int i = 0; i < consoleId.Length; i++)
            {
                if (!char.IsDigit(consoleId[i]))
                    return -1;
            }

            return Int32.Parse(consoleId);
        }

        public void DispenseProduct(string productName)
        {
            Console.WriteLine();
            DisplayLine(new string('-', 30), ConsoleColor.Green);
            DisplayLine($"{productName} has been dispensed!", ConsoleColor.DarkGreen);
            DisplayLine(new string('-', 30), ConsoleColor.Green);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            DisplayLine("Go back->Enter", ConsoleColor.DarkGreen);
            Console.ReadKey();
        }

        public int ConfirmPay()
        {
            DisplayLine(new string('-', 80), ConsoleColor.Green);
            Display(new string(' ', 25), ConsoleColor.White);
            DisplayLine("Continue to payment?[Y] or [N]", ConsoleColor.DarkGreen);
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

        public int AskForPaymentMethod(List<PaymentMethod> paymentMethods)
        {
            Console.WriteLine();
            DisplayLine("Select a payment method:", ConsoleColor.Green);
            foreach (PaymentMethod paymentMethod in paymentMethods)
            {
                DisplayLine(new string('=', 20), ConsoleColor.Green);
                DisplayLine($"{paymentMethod.Id}.{paymentMethod.Name}", ConsoleColor.DarkGreen);
            }
            DisplayLine(new string('=', 20), ConsoleColor.Green);
            Console.ForegroundColor = ConsoleColor.Green;
            return Int32.Parse(Console.ReadLine());
        }

        public void InvalidProductId(int id)
        {
            Console.WriteLine();
            DisplayLine($"Invalid product ID!Try again,press enter.", ConsoleColor.Red);
            Console.ReadKey();
        }

        public void ConfirmPayError()
        {
            Console.WriteLine();
            DisplayLine($"Invalid option.Try Again!", ConsoleColor.Red);
            Console.WriteLine();
        }
    }
}