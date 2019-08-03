using Salem.Formatters;
using Salem.Outputs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Salem
{
    public interface ILogger
    {
        string Scope { get; set; }
        List<IOutput> Outputs { get; }
        List<IFormatter> Formatters { get; }
        List<LogLevel> LogLevels { get; }

        void Log(string logLevel, string content, string scope = "");
        void Log(string logLevel, object content, string scope = "");
        Task Log(Func<bool> task, string message, string successMessage, string failMessage, string logLevel = "Awaiting", string successLoglevel = "Success", string failLogLevel = "Error", string scope = "");
    }
}