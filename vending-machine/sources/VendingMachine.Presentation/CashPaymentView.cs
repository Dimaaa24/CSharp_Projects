using Nagarro.VendingMachine.PresentationLayer;

namespace Nagarro.VendingMachine.Presentation
{
    internal class CashPaymentView : DisplayBase, ICashPaymentView
    {
        public string AskForMoney(decimal productPrice, decimal currentBalance)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            DisplayLine($"Owed money:{productPrice - currentBalance}", ConsoleColor.Green);
            DisplayLine("Accepted banknotes:100,50,20,10,5,1", ConsoleColor.Green);
            DisplayLine("Accepted coins:0.50,0.10,0.05,0.01", ConsoleColor.Green);
            DisplayLine("Input x to cancel payment.", ConsoleColor.DarkGreen);
            DisplayLine("Add money:", ConsoleColor.Green);

            string money = Console.ReadLine();

            return money;
        }

        public void GiveBackChange(decimal currency, int counter)
        {
            Console.WriteLine($"{counter} of {currency} lei");
        }

        public void TotalOwedBalance(decimal balance)
        {
            DisplayLine($"Total Owed:{balance} lei", ConsoleColor.DarkGreen);
        }

        public void DisplayChangeOwed(decimal change)
        {
            Console.WriteLine();
            DisplayLine($"Change owed:{change:F2}", ConsoleColor.DarkGreen);
        }

        public void InvalidBanknoteOrCoin()
        {
            Console.WriteLine();
            DisplayLine("Invalid banknote or coin!", ConsoleColor.Red);
        }

        public void CashPaymentCanceled(decimal paidMoney)
        {
            Console.WriteLine();
            DisplayLine($"User has been paid back {paidMoney} lei!", ConsoleColor.Green);
            Console.WriteLine();
            DisplayLine("Cash payment canceled! Press enter to go back.",ConsoleColor.Red);
            Console.ReadKey();
        }
    }
}