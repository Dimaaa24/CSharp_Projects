using System;

namespace RemoteLearning.BigTree.Business
{
    public class JobEndedEventArgs : EventArgs
    {
        public JobResult JobResult { get; }

        public JobEndedEventArgs(JobResult jobResult)
        {
            JobResult = jobResult;
        }
    }
}