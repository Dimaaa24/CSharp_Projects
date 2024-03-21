using System.Reflection;

namespace Eyeglass
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly testAssembly = Assembly.LoadFrom(args[0]);
            Console.WriteLine($"Name:{testAssembly.FullName}");

            Type[] types = testAssembly.GetTypes();
            foreach (Type type in types)
            {
                Console.WriteLine($"Type:{type.FullName}");
                MemberInfo[] membersInfo = type.GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                foreach (MemberInfo member in membersInfo)
                {
                    Console.WriteLine($"{member.Name}:");
                    switch (member)
                    {
                        case FieldInfo fieldInfo:
                            Console.WriteLine($"FieldType:{fieldInfo.FieldType}");
                            break;

                        case PropertyInfo propertyInfo:
                            Console.WriteLine($"PropertyType: {propertyInfo.PropertyType}");
                            Console.WriteLine($"CanRead: {propertyInfo.CanRead}");
                            Console.WriteLine($"CanWrite: {propertyInfo.CanWrite}");
                            break;

                        case EventInfo eventInfo:
                            Console.WriteLine($"EventHandlerType: {eventInfo.EventHandlerType}");
                            break;

                        case MethodInfo methodInfo:
                            Console.WriteLine($"ReturnType:{methodInfo.ReturnType}");
                            break;
                        default:
                            Console.WriteLine("Invalid type of member");
                            break;
                    }
                }
            }

        }
    }
}
