using System;
using System.IO;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Log.txt");

            Exception exception = new Exception("Test exception");

            var log1 = new FileLogger<string>(path);
            log1.LogInfo("LogInfo");
            log1.LogWarning("LogWarning");
            log1.LogError("LogError", exception);

            var log2 = new FileLogger<int>(path);
            log2.LogInfo("LogInfo");
            log2.LogWarning("LogWarning");
            log2.LogError("LogError", exception);

            var log3 = new FileLogger<bool>(path);
            log3.LogInfo("LogInfo");
            log3.LogWarning("LogWarning");
            log3.LogError("LogError", exception);

            Console.ReadLine();
        }
    }
}