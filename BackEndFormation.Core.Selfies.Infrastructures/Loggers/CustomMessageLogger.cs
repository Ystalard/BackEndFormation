using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndFormation.Core.Selfies.Infrastructures.Loggers
{
    public class CustomMessageLogger : ILogger
    {
        #region public methods
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel != LogLevel.Trace;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            Console.WriteLine($"[{DateTime.Now}]: [{logLevel}] {eventId.Id} - {formatter(state, exception)}");
            Debug.WriteLine($"[{DateTime.Now}]: [{logLevel}] {eventId.Id} - {formatter(state, exception)}");
        }
        #endregion
    }
}
