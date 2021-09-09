using Microsoft.Extensions.Logging;
using System;

namespace OwnLogger.Business.Interfaces
{
    public interface ILogger
    {
        void Log(string message);
        void Log(string message, LogLevel logLevel);
        void Log(Exception exception, LogLevel logLevel);
    }
}
