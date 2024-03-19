using System.Diagnostics;

namespace Boxing_and_Unboxing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<object> objectList = new List<object>();
            List<int> intList = new List<int>();
            Random random = new Random();

            while (objectList.Count < 50000000)
            { 
                objectList.Add(random.Next());
                intList.Add(random.Next());
            }

            Console.WriteLine("For 50 million values:");
            Console.WriteLine("No Boxing or Unboxing: " + Normal(intList));
            Console.WriteLine("Boxing: " + Boxing(intList, objectList));
            Console.WriteLine("Unboxing: " + Unboxing(intList, objectList));
        }

        static string GetElapsedTime(Stopwatch stopWatch)
        {
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = string.Format($"{ts.Minutes:00}min {ts.Seconds:00}sec {ts.Milliseconds:00}ms");
            return elapsedTime;
        }

        static string Boxing(List<int> intList, List<object> objectList)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            foreach (int element in intList)
            {
                objectList.Add(element);
            }
            stopWatch.Stop();
            return GetElapsedTime(stopWatch);
        }

        static string Unboxing(List<int> intList, List<object> objectList)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            foreach (object element in objectList)
            {
                intList.Add((int)element);
            }
            stopWatch.Stop();
            return GetElapsedTime(stopWatch);
        }

        static string Normal(List<int> intList)
        {
            Stopwatch stopWatch = new Stopwatch();
            List<int> list = new List<int>();
            stopWatch.Start();
            foreach (int element in intList)
            {
                list.Add(element);
            }
            stopWatch.Stop();
            return GetElapsedTime(stopWatch);
        }
    }
}