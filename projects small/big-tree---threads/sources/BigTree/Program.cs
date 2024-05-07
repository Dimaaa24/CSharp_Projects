using System;
using DustInTheWind.ConsoleTools;
using RemoteLearning.BigTree.Business;
using RemoteLearning.BigTree.Presentation;

namespace RemoteLearning.BigTree
{
    internal static class Program
    {
        private static void Main()
        {
            try
            {
                ApplicationHeaderControl applicationHeader = new ApplicationHeaderControl();
                applicationHeader.Display();

                JobsWorld jobsWorld = new JobsWorld();

                JobsView jobsView = new JobsView();
                JobsPresenter jobsPresenter = new JobsPresenter(jobsWorld, jobsView);

                jobsWorld.Run();
            }
            catch (Exception ex)
            {
                CustomConsole.WriteLineError(ex.ToString());
            }
            finally
            {
                Pause.QuickDisplay();
            }
        }
    }
}