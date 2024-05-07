using System;

namespace RemoteLearning.BigTree.Business
{
    public class JobStartingEventArgs : EventArgs
    {
        public string JobDescription { get; }

        public JobStartingEventArgs(string jobDescription)
        {
            JobDescription = jobDescription;
        }
    }
}