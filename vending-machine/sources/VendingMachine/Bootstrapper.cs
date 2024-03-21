using Nagarro.VendingMachine.Authentication;
using Autofac;
using Nagarro.VendingMachine.DataAccess;
using Nagarro.VendingMachine.DataAccess.Sqlite;
using Nagarro.VendingMachine.Payment;
using Nagarro.VendingMachine.Presentation;
using Nagarro.VendingMachine.PresentationLayer;
using System.Configuration;

namespace Nagarro.VendingMachine
{
    internal class Bootstrapper
    {
        public void Run()
        {
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

            builder.RegisterType<MainView>().As<IMainView>();
            builder.RegisterType<LoginView>().As<ILoginView>();
            builder.RegisterType<ShelfView>().As<IShelfView>();
            builder.RegisterType<BuyView>().As<IBuyView>();
            builder.RegisterType<CardPaymentView>().As<ICardPaymentView>();
            builder.RegisterType<CashPaymentView>().As<ICashPaymentView>();

            string connectionString = ConfigurationManager.ConnectionStrings["DBProductRepository"].ConnectionString;
            builder.RegisterType<SQLiteProductRepository>().As<IProductRepository>().WithParameter("connectionString", connectionString).SingleInstance();

            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>();

            var assemblyPaymentAlgorithms = typeof(IPaymentAlgorithm).Assembly;
            builder.RegisterAssemblyTypes(assemblyPaymentAlgorithms).As<IPaymentAlgorithm>();

            builder.RegisterType<PaymentService>().As<IPaymentService>();

            var assemblyUseCases = typeof(IUseCase).Assembly;
            builder.RegisterAssemblyTypes(assemblyUseCases).As<IUseCase>();

            builder.RegisterType<VendingMachineApplication>().As<IVendingMachineApplication>();

            Container = builder.Build();
        }
    }
}