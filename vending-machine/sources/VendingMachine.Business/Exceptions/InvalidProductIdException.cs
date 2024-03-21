namespace Nagarro.VendingMachine.Exceptions
{
    internal class InvalidProductIdException : Exception
    {
        private const string DefaultMessage = "\nInvalid product for ID {0}";

        public InvalidProductIdException(int id) : base(string.Format(DefaultMessage, id))
        {
        }
    }
}