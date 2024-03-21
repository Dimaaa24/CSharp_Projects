using System.Reflection;

namespace Nagarro.VendingMachine.Presentation
{
    internal class ApplicationHeaderControl : DisplayBase
    {
        private readonly string applicationName;
        private readonly Version applicationVersion;

        public ApplicationHeaderControl()
        {
            Assembly assembly = Assembly.GetEntryAssembly();

            AssemblyProductAttribute assemblyProductAttribute = assembly.GetCustomAttribute<AssemblyProductAttribute>();
            applicationName = assemblyProductAttribute.Product;

            AssemblyName assemblyName = assembly.GetName();
            applicationVersion = assemblyName.Version;
        }

        public void Display()
        {
            DisplayLine(new string('=', 80), ConsoleColor.Magenta);
            Display(new string(' ', 28), ConsoleColor.Magenta);
            DisplayLine($"~  {applicationName}-{applicationVersion.ToString(2)}  ~", ConsoleColor.Magenta);
            DisplayLine(new string('=', 80), ConsoleColor.Magenta);
        }
    }
}