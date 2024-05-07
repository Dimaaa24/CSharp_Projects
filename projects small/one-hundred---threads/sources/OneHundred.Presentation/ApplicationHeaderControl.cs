using DustInTheWind.ConsoleTools;

namespace RemoteLearning.OneHundred.Presentation
{
    public class ApplicationHeaderControl
    {
        public void Display()
        {
            CustomConsole.WriteLineEmphasies("Thread Concurrency");
            CustomConsole.WriteLineEmphasies(new string('=', 79));
        }
    }
}