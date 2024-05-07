using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System;

namespace RemoteLearning.OneHundred.Business.Jobs
{
    internal class ManualEventHandlerJob : IJob
    {
        private static EventWaitHandle eventHandle;

        private long value;

        private static long threadCount;

        public ushort ThreadCount { get; set; }

        public ulong IncrementCount { get; set; }

        public string Description { get; } = "Sixth method-manual event handler.";

        public JobResult Execute()
        {
            threadCount = 0;
            eventHandle = new EventWaitHandle(false, EventResetMode.ManualReset);

            eventHandle.Reset();

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

            eventHandle.Set();

            foreach (Thread thread in threads)
                thread.Join();
        }

        private Thread StartNewThread()
        {
            Thread thread = new Thread(o =>
            {
                eventHandle.WaitOne();

                for (ulong i = 0; i < IncrementCount; i++)
                {
                    Interlocked.Increment(ref value);
                }

                Interlocked.Decrement(ref threadCount);

                if (threadCount == 0)
                    eventHandle.Set();
            });

            Interlocked.Increment(ref threadCount);

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
