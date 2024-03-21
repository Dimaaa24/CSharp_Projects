namespace Nagarro.VendingMachine.Exceptions
{
    internal class InsufficientStockException : Exception
    {
        private const string DefaultMessage = "\nNot enough items in stock for Product{0}!";

        public InsufficientStockException(string name) : base(string.Format(DefaultMessage, name))
        {
        }
    }
}