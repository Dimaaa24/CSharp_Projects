using System;
using System.Collections.Generic;
using RemoteLearning.TheUniverse.Application.GetAllStars;
using RemoteLearning.TheUniverse.Infrastructure;

namespace RemoteLearning.TheUniverse.Presentation.Commands
{
    internal class DisplayAllStarsCommand
    {
        private readonly RequestBus requestBus;

        public DisplayAllStarsCommand(RequestBus requestBus)
        {
            this.requestBus = requestBus ?? throw new ArgumentNullException(nameof(requestBus));
        }

        public void Execute()
        {
            GetAllStarsRequest request = new GetAllStarsRequest();
            List<StarInfo> starInfos = requestBus.Send<GetAllStarsRequest, List<StarInfo>>(request);

            DisplayStars(starInfos);
        }

        private static void DisplayStars(IEnumerable<StarInfo> starInfos)
        {
            Console.WriteLine();

            Console.WriteLine("The stars in this universe:");

            foreach (StarInfo starInfo in starInfos)
                Console.WriteLine($"Star '{starInfo.StarName}' from galaxy '{starInfo.GalaxyName}'.");
        }
    }
}