﻿using Nagarro.VendingMachine.Models;
using Nagarro.VendingMachine.PresentationLayer;

namespace Nagarro.VendingMachine.Presentation
{
    internal sealed class ShelfView : DisplayBase, IShelfView
    {
        public void DisplayHeader()
        {
            ChangeBackgroundAndForeground(ConsoleColor.White, ConsoleColor.Cyan);
            DisplayLine(new string('=', 80), ConsoleColor.Cyan);
            Display(new string(' ', 30), ConsoleColor.White);
            DisplayLine("~  Available Items  ~", ConsoleColor.Cyan);
            DisplayLine(new string('=', 80), ConsoleColor.Cyan);
        }

        public void DisplayProducts(IEnumerable<Product> products)
        {
            if (products == null)
            {
                DisplayLine("No products available!", ConsoleColor.Red);
                Console.ReadKey();
                return;
            }
            DisplayLine(new string('=', 80), ConsoleColor.Cyan);
            foreach (Product product in products)
            {
                if (product.Quantity > 0)
                {
                    DisplayLine($"ID:{product.Id} \t Name:{product.Name} \t Price:{product.Price} lei \t Stock:{product.Quantity}", ConsoleColor.DarkCyan);
                }
            }
            DisplayLine(new string('=', 80), ConsoleColor.Cyan);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            DisplayLine("Go back->Enter", ConsoleColor.DarkCyan);
            Console.ReadKey();
        }
    }
}