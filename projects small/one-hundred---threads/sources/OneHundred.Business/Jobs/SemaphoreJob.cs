using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteLearning.OneHundred.Business.Jobs
{
    internal class SemaphoreJob : IJob
    {
        private static Semaphore semaphore;

        private long value;

        public ushort ThreadCount { get; set; }

        public ulong IncrementCount { get; set; }

        public string Description { get; } = "Fifth method-semaphore.";

        public JobResult Execute()
        {
            semaphore = new Semaphore(1, 1);

            value = 0;

            TimeSpan elapsedTime = MeasureExecutionTime(RunAllThreads);

            return new JobResult
            {
                Value = value,
                ElapsedTime = elapsedTime
            };
        }

        private void RunAllThreads()
        {
            List<Thread> threads = Enumerable.Range(0, ThreadCount)
                .Select(x => StartNewThread())
                .ToList();

            foreach (Thread thread in threads)
                thread.Join();
        }

        private Thread StartNewThread()
        {
            Thread thread = new Thread(o =>
            {
                semaphore.WaitOne();

                for (ulong i = 0; i < IncrementCount; i++)
                    value++;

                semaphore.Release();
            });

            thread.Start();

            return thread;
        }

        private static TimeSpan MeasureExecutionTime(Action action)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            action();
            return stopwatch.Elapsed;
        }
    }
}
