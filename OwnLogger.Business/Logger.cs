using OwnLogger.Business.Entities;
using OwnLogger.Business.Interfaces;
using System;
using System.IO;

namespace OwnLogger.Business
{
    public class Logger: ILogger
    {
        public void Log(string message)
        {
            WriteToFile(new Log
            {
                Message = message,
                LogLevel = Microsoft.Extensions.Logging.LogLevel.Debug,
                Created = DateTime.Now
            });
        }

        public void Log(string message, Microsoft.Extensions.Logging.LogLevel logLevel)
        {
            WriteToFile(new Log
            {
                Message = message,
                LogLevel = logLevel,
                Created = DateTime.Now
            });
        }

        public void Log(Exception exception, Microsoft.Extensions.Logging.LogLevel logLevel)
        {

            WriteToFile(new Log
            {
                Message = exception.Message,
                LogLevel = logLevel,
                Created = DateTime.Now
            });
        }

        private static void WriteToFile(Log log)
        {
            using StreamWriter file = new("logFile.txt", append: true);
            file.WriteLine($"{log.Created};{log.LogLevel};{log.Message}");
        }
    }
}
