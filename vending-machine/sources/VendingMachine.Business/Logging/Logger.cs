using log4net;

namespace VendingMachine.Business.Logging
{
    public class Logger<K> : ILogger<K>
    {
        private ILog log;
        public Logger()
        {
            log = LogManager.GetLogger(typeof(K));
        }
        public void Error(string message)
        {
            log.Error(message);
        }

        public void Warn(string message)
        {
            log.Warn(message);
        }

        public void Info(string message)
        {
            log.Info(message);
        }

        public void Debug(string message) 
        {
            log.Debug(message);
        }

    }
}
