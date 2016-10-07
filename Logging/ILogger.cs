using System;

namespace Logging
{
    public interface ILogger
    {
        void LogSuccess(LoggingData[] loggingData);
        void LogError(LoggingData[] loggingData, Exception exception);
    }
}