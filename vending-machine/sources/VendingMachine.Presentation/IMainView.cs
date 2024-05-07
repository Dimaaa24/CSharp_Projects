using VendingMachine.Presentation.Commands;

namespace VendingMachine.Presentation
{
    internal interface IMainView
    {
        ICommands ChooseCommand(IEnumerable<ICommands> useCases);

        void DisplayApplicationHeader();
    }
}