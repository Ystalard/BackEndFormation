using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndFormation.Core.Selfies.Infrastructures.Loggers
{
    public class CustomLoggerProvider : ILoggerProvider
    {
        #region Fields
        private ConcurrentDictionary<string, CustomMessageLogger> _loggers = new();
        #endregion

        #region public methods
        public ILogger CreateLogger(string categoryName)
        {
            _loggers.GetOrAdd(categoryName, name => new CustomMessageLogger());
            return _loggers[categoryName];
        }

        public void Dispose()
        {
            _loggers.Clear();
        }
        #endregion
    }
}
