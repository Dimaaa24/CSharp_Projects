using RemoteLearning.BigTree.ThirdPartyLibrary;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RemoteLearning.BigTree.Business.Jobs
{
    internal class FirstImplementation : IJob
    {
        public int LevelCount { get; set; }

        public string Description { get; } = "Third implementation-generation using task";

        public JobResult Execute()
        {
            Node tree = null;

            TimeSpan elapsedTime = MeasureExecutionTime(async () => { tree = await GenerateNodeAsync(LevelCount - 1); });

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
                node.LeftNode = await GenerateNodeAsync(descendentLevelCount - 1);
                node.RightNode = await GenerateNodeAsync(descendentLevelCount - 1);

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
