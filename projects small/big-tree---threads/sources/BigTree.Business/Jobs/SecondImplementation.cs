using RemoteLearning.BigTree.ThirdPartyLibrary;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RemoteLearning.BigTree.Business.Jobs
{
    internal class SecondImplementation : IJob
    {
        public int LevelCount { get; set; }

        public string Description { get; } = "Second generation implementation";

        public JobResult Execute()
        {
            Node tree = null;

            TimeSpan elapsedTime = MeasureExecutionTime(async() => { tree = await GenerateNodeAsync(LevelCount - 1); });

            return new JobResult
            {
                Tree = tree,
                ElapsedTime = elapsedTime
            };
        }

        private async Task<Node> GenerateNodeAsync(int descendentLevelCount)
        {
            Node node = new Node
            {
                Values = ThirdPartyCalculator.Calculate()
            };

            if (descendentLevelCount > 0)
            {
                Task<Node> leftNodeTask = GenerateNodeAsync(descendentLevelCount - 1);
                Task<Node> rightNodeTask = GenerateNodeAsync(descendentLevelCount - 1);

                await Task.WhenAll(leftNodeTask, rightNodeTask);

                node.LeftNode = await leftNodeTask;
                node.RightNode = await rightNodeTask;
            }

            return node;
        }

        private static TimeSpan MeasureExecutionTime(Action action)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            action();
            return stopwatch.Elapsed;
        }
    }
}
