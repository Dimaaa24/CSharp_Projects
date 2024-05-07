using System;
using System.Collections.Generic;
using VendingMachine.Business.Logging;
using VendingMachine.Presentation;
using VendingMachine.Presentation.Commands;

namespace Nagarro.VendingMachine
{
    internal class VendingMachineApplication : IVendingMachineApplication
    {
        private readonly IEnumerable<ICommands> commands;
        private readonly IMainView mainView;
        private readonly ILogger<VendingMachineApplication> logger;

        public VendingMachineApplication(IEnumerable<ICommands> commands, IMainView mainView, ILogger<VendingMachineApplication> logger)
        {
            this.commands = commands ?? throw new ArgumentNullException(nameof(commands));
            this.mainView = mainView ?? throw new ArgumentNullException(nameof(mainView));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Run()
        {
            logger.Info("VendingMachine application started.");

            mainView.DisplayApplicationHeader();

            while (true)
            {
                List<ICommands> availableCommands = GetExecutableUseCases();
                try
                {
                    mainView.DisplayApplicationHeader();
                    ICommands command = mainView.ChooseCommand(availableCommands);
                    command.Execute();
                }
                catch (Exception e)
                {
                    logger.Error(e.Message + e.StackTrace + e.InnerException);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
            }
        }

        private List<ICommands> GetExecutableUseCases()
        {
            List<ICommands> executableUseCases = new List<ICommands>();

            foreach (ICommands command in commands)
            {
                if (command.CanExecute)
                    executableUseCases.Add(command);
            }

            return executableUseCases;
        }
    }
}