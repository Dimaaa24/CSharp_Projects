using Nagarro.VendingMachine.Presentation;
using Nagarro.VendingMachine.PresentationLayer;

namespace VendingMachine.Presentation
{
    internal class ReportView : DisplayBase, IReportView
    {
        public void ReportHeader(string name)
        {
            ChangeBackgroundAndForeground(ConsoleColor.White, ConsoleColor.DarkYellow);
            DisplayLine(new string('=', 80), ConsoleColor.DarkYellow);
            Display(new string(' ', 30), ConsoleColor.White);
            DisplayLine($"~  {name} Report  ~", ConsoleColor.DarkYellow);
            DisplayLine(new string('=', 80), ConsoleColor.DarkYellow);

        }

        public void SuccesfullGeneration()
        {
            Console.WriteLine();
            DisplayLine("\n\tSuccesfully generated report!Press enter\n", ConsoleColor.DarkYellow);
            Console.WriteLine();
            DisplayLine("\n\nGo Back->Enter\n", ConsoleColor.DarkYellow);
            Console.ReadKey();
        }

        public DateTime AskForStartDate()
        {
            int year;
            int month;
            int day;
            Console.WriteLine();
            DisplayLine(" " + new string('_', 45), ConsoleColor.DarkYellow);
            DisplayLine("| Selecting a start date to generate report:  |", ConsoleColor.DarkYellow);
            DisplayLine("| Input the year:                             |", ConsoleColor.DarkYellow);
            year = int.Parse(Console.ReadLine());
            DisplayLine("| Input the month:                            |", ConsoleColor.DarkYellow);
            month = int.Parse(Console.ReadLine());
            DisplayLine("| Input the day:                              |", ConsoleColor.DarkYellow);
            day = int.Parse(Console.ReadLine());
            DisplayLine(" " + new string('_', 45), ConsoleColor.DarkYellow);
            return new DateTime(year, month, day, 0, 0, 0);
        }

        public DateTime AskForEndDate()
        {
            int year;
            int month;
            int day;
            Console.WriteLine();
            DisplayLine(" " + new string('_', 45), ConsoleColor.DarkYellow);
            DisplayLine("| Selecting a end date to generate report:    |", ConsoleColor.DarkYellow);
            DisplayLine("| Input the year:                             |", ConsoleColor.DarkYellow);
            year = int.Parse(Console.ReadLine());
            DisplayLine("| Input the month:                            |", ConsoleColor.DarkYellow);
            month = int.Parse(Console.ReadLine());
            DisplayLine("| Input the day:                              |", ConsoleColor.DarkYellow);
            day = int.Parse(Console.ReadLine());
            DisplayLine(" " + new string('_', 45), ConsoleColor.DarkYellow);
            return new DateTime(year, month, day, 23, 59, 59);
        }
    }
}
