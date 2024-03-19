using RemoteLearning.TheUniverse.Application.AddGalaxy;
using RemoteLearning.TheUniverse.Application.AddStar;
using RemoteLearning.TheUniverse.Application.GetAllStars;
using RemoteLearning.TheUniverse.Infrastructure;
using RemoteLearning.TheUniverse.Presentation;

namespace RemoteLearning.TheUniverse
{
    internal class Bootstrapper
    {
        private static RequestBus requestBus;

        public void Run()
        {
            requestBus = new RequestBus();
            ConfigureRequestBus();
            DisplayApplicationHeader();
            RunUserCommandProcessLoop();
        }

        private static void ConfigureRequestBus()
        {
            requestBus.RegisterHandler(typeof(AddStarRequest), typeof(AddStarRequestHandler));
            requestBus.RegisterHandler(typeof(AddGalaxyRequest), typeof(AddGalaxyRequestHandler));
            requestBus.RegisterHandler(typeof(GetAllStarsRequest), typeof(GetAllStarsRequestHandler));
        }

        private static void DisplayApplicationHeader()
        {
            ApplicationHeader applicationHeader = new ApplicationHeader();
            applicationHeader.Display();
        }

        private static void RunUserCommandProcessLoop()
        {
            Prompter prompter = new Prompter(requestBus);
            prompter.ProcessUserInput();
        }
    }
}