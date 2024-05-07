namespace VendingMachine.Presentation
{
    internal interface IUseCaseFactory
    {
        IUseCase Create<IUseCase>();
    }
}