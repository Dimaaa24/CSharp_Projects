﻿namespace Nagarro.VendingMachine.PresentationLayer
{
    internal interface IMainView
    {
        IUseCase ChooseCommand(IEnumerable<IUseCase> useCases);
        void DisplayApplicationHeader();
    }
}