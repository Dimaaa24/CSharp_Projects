using Autofac;
using log4net.Config;
using Microsoft.EntityFrameworkCore;
using Nagarro.VendingMachine.Authentication;
using Nagarro.VendingMachine.DataAccess;
using Nagarro.VendingMachine.Payment;
using Nagarro.VendingMachine.Presentation;
using Nagarro.VendingMachine.PresentationLayer;
using System.Configuration;
using System.IO;
using VendingMachine;
using VendingMachine.Business.Logging;
using VendingMachine.Business.ReportsDocuments;
using VendingMachine.DataAccess.Sqlite;
using VendingMachine.Presentation;
using VendingMachine.Presentation.Commands;

namespace Nagarro.VendingMachine
{
    internal class Bootstrapper
    {
        public void Run()
        {
            XmlConfigurator.Configure(new FileInfo("log4net.config"));

            BuildApplication();

            using (var scope = Container.BeginLifetimeScope())
            {
                IVendingMachineApplication vendingMachineApplication = scope.Resolve<IVendingMachineApplication>();
                vendingMachineApplication.Run();
            }
        }

        private static IContainer Container { get; set; }

        private static void BuildApplication()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterGeneric(typeof(Logger<>)).As(typeof(ILogger<>));

            builder.RegisterType<MainView>().As<IMainView>();
            builder.RegisterType<LoginView>().As<ILoginView>();
            builder.RegisterType<ShelfView>().As<IShelfView>();
            builder.RegisterType<BuyView>().As<IBuyView>();
            builder.RegisterType<ReportView>().As<IReportView>();
            builder.RegisterType<CardPaymentView>().As<ICardPaymentView>();
            builder.RegisterType<CashPaymentView>().As<ICashPaymentView>();

            string connectionString = ConfigurationManager.ConnectionStrings["DBProductRepository"].ConnectionString;
            var optionsBuilder = new DbContextOptionsBuilder<VendingMachineContext>();
            optionsBuilder.UseSqlite(connectionString);
            builder.Register(c => new VendingMachineContext(optionsBuilder.Options)).As<VendingMachineContext>().InstancePerLifetimeScope();
            builder.RegisterType<EFSqliteProductRepository>().As<IProductRepository>().SingleInstance();
            builder.RegisterType<EFSqliteSaleRepository>().As<ISaleRepository>().SingleInstance();

            string fileType = ConfigurationManager.AppSettings["ReportFormat"];
            string folderLocation = ConfigurationManager.AppSettings["Folder"];
            builder.RegisterType<FileService>().As<IFileService>().WithParameter("folderAddress", folderLocation).SingleInstance();

            if (fileType.Equals("JSON"))
            {
                builder.RegisterType<JSONReportSerializer>().As<IReportSerializer>();
            }
            else
            {
                builder.RegisterType<XMLReportSerializer>().As<IReportSerializer>();
            }

            builder.RegisterType<ReportService>().As<IReportService>();

            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().SingleInstance();

            var assemblyPaymentAlgorithms = typeof(IPaymentAlgorithm).Assembly;
            builder.RegisterAssemblyTypes(assemblyPaymentAlgorithms).As<IPaymentAlgorithm>();

            builder.RegisterType<PaymentService>().As<IPaymentService>();

            var assemblyUseCases = typeof(IUseCase).Assembly;
            builder.RegisterAssemblyTypes(assemblyUseCases).As<IUseCase>().AsSelf();

            var assemblyCommands = typeof(LookCommand).Assembly;
            builder.RegisterAssemblyTypes(assemblyCommands).As<ICommands>();

            builder.RegisterType<UseCaseFactory>().As<IUseCaseFactory>();

            builder.RegisterType<VendingMachineApplication>().As<IVendingMachineApplication>();

            Container = builder.Build();
        }
    }
}