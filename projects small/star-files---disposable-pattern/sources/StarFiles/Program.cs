using System;
using DustInTheWind.ConsoleTools;

namespace RemoteLearning.StarFiles
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                UseCase useCase = new UseCase();
                useCase.Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                CustomConsole.WriteError(ex);
            }
            finally
            {
                Pause.QuickDisplay();
            }
        }
    }
}