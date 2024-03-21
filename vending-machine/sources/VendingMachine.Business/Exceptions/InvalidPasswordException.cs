namespace Nagarro.VendingMachine.Exceptions
{
    internal class InvalidPasswordException : Exception
    {
        private const string DefaultMessage = "Invalid password";

        public InvalidPasswordException() : base(DefaultMessage)
        {
        }
    }
}