using Nagarro.VendingMachine.PresentationLayer;
using System;
using System.Collections.Generic;

namespace Nagarro.VendingMachine
{
    internal class VendingMachineApplication : IVendingMachineApplication
    {
        private readonly IEnumerable<IUseCase> useCases;
        private readonly IMainView mainView;

        public VendingMachineApplication(IEnumerable<IUseCase> useCases, IMainView mainView)
        {
            this.useCases = useCases ?? throw new ArgumentNullException(nameof(useCases));
            this.mainView = mainView ?? throw new ArgumentNullException(nameof(mainView));
        }

        public void Run()
        {
            mainView.DisplayApplicationHeader();

            while (true)
            {
                List<IUseCase> availableUseCases = GetExecutableUseCases();
                try
                {
                    mainView.DisplayApplicationHeader();
                    IUseCase useCase = mainView.ChooseCommand(availableUseCases);
                    useCase.Execute();
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
            }
        }

        private List<IUseCase> GetExecutableUseCases()
        {
            List<IUseCase> executableUseCases = new List<IUseCase>();

            foreach (IUseCase useCase in useCases)
            {
                if (useCase.CanExecute)
                    executableUseCases.Add(useCase);
            }

            return executableUseCases;
        }
    }
}