namespace Nagarro.VendingMachine.Presentation
{
    internal class DisplayBase
    {
        protected void ChangeBackgroundAndForeground(ConsoleColor backgroundColor, ConsoleColor foregroundColor)
        {
            Console.Clear();
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
        }

        protected void DisplayLine(string message, ConsoleColor color)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = oldColor;
        }

        protected void Display(string message, ConsoleColor color)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ForegroundColor = oldColor;
        }
    }
}