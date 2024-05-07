namespace VendingMachine.Business.Logging
{
    public interface ILogger<T>
    {
        void Error(string message);
        void Info(string message);
        void Warn(string message);
        void Debug(string message);
    }
}