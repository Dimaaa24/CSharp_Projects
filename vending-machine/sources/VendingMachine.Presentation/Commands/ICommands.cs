namespace VendingMachine.Presentation.Commands
{
    internal interface ICommands
    {
        string Name { get; }

        string Description { get; }

        bool CanExecute { get; }

        void Execute();
    }
}