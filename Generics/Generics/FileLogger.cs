using System;
using System.IO;
namespace Generics
{
    public interface ILogger
    {
        public void LogInfo(string message);
        public void LogWarning(string message);
        public void LogError(string message, Exception ex);

    }
    public class FileLogger<T> : ILogger
    {
        private string _path;

        public FileLogger(string path)
        {
            _path = path;
            if (!File.Exists(path))
            {
                string startLog = "Начало логов\n";
                File.WriteAllText(path, startLog);
            }
        }
        public void LogInfo(string message)
        {
            File.AppendAllText(_path,$"[Info]: [{typeof(T).Name}] : {message}");
        }

        public void LogWarning(string message)
        {
            File.AppendAllText(_path,$"[Warning]: [{typeof(T).Name}] : {message}");
        }

        public void LogError(string message, Exception ex)
        {
            File.AppendAllText(_path,$"[Error] : [{typeof(T).Name}] : {message}. {ex.Message}");
        }
    }
}