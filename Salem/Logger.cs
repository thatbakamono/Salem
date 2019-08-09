using Salem.Extensions;
using Salem.Formatters;
using Salem.Outputs;
using Pastel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Salem
{
    public class Logger : ILogger
    {
        public string Scope { get; set; }
        public int BiggestLength { get; } = 0;

        public List<IOutput> Outputs { get; } = new List<IOutput>() { new ConsoleOutput() };
        public List<IFormatter> Formatters { get; } = new List<IFormatter>();
        public List<LogLevel> LogLevels { get; }  = new List<LogLevel>()
        {
            new LogLevel("Error", "[×]", Color.OrangeRed),
            new LogLevel("Warning", "[!]", Color.FromArgb(248, 250, 107)),
            new LogLevel("Success", "[v]", Color.LawnGreen),
            new LogLevel("Info", "[i]", Color.Cyan),
            new LogLevel("Stacktrace", "[o]", Color.FromArgb(248, 250, 107)),
            new LogLevel("Awaiting", "[%]", Color.DeepSkyBlue)
        };

        private static object lck = new object();

        public Logger(string scope)
        {
            Scope = scope;

            Formatters.Add(new ExceptionFormatter(this));
            Formatters.Add(new IListFormatter(this));
            Formatters.Add(new IDictionaryFormatter(this));

            foreach (var logLevel in LogLevels)
            {
                if (BiggestLength < logLevel.Name.Length)
                    BiggestLength = logLevel.Name.Length;
            }
        }

        public void Log(string loglevel, string content, string scope = "")
        {
            lock (lck)
            {
                InternalLog(loglevel, content, scope);
            }
        }

        public void Log(string loglevel, object input, string scope = "")
        {
            lock (lck)
            {
                var inputType = input.GetType();
                var inputInterfaces = inputType.GetInterfaces();

                foreach (var formatter in Formatters)
                {
                    var formatterType = formatter.GetType();
                    var interfaces = formatterType.GetInterfaces();

                    foreach (var interfac in interfaces)
                    {
                        if (interfac.IsGenericType)
                        {
                            var genericArgument = interfac.GetGenericArguments()[0];

                            if (genericArgument == inputType)
                            {
                                formatter.Format(loglevel, input);

                                return;
                            }
                            else
                            {
                                foreach (var inputInterface in inputInterfaces)
                                {
                                    if (genericArgument == inputInterface)
                                    {
                                        formatter.Format(loglevel, input);

                                        return;
                                    }
                                }
                            }
                        }
                    }
                }

                InternalLog(loglevel, input.ToString(), scope);
            }
        }

        public async Task Log(Func<bool> task, string message, string successMessage, string failMessage, string logLevel = "Awaiting", string successLogLevel = "Success", string failLogLevel = "Error", string scope = "")
        {
            await Task.Run(() =>
            {
                var y = 0;
                var x = 0;
                var successMessageLength = successMessage.Length + Math.Abs(successMessage.Length - message.Length);
                var failMessageLength = failMessage.Length + Math.Abs(failMessage.Length - message.Length);

                lock (lck)
                {
                    InternalLog(logLevel, message, scope);

                    y = Console.CursorTop - 1;
                    x = Console.CursorLeft;
                }

                var result = task();

                lock (lck)
                {
                    var ynew = Console.CursorTop;
                    var xnew = Console.CursorLeft;

                    Console.SetCursorPosition(0, y);
                    InternalLog(result ? successLogLevel : failLogLevel, result ? successMessage.Expand(successMessageLength) : failMessage.Expand(failMessageLength), scope);
                    Console.SetCursorPosition(xnew, ynew);
                }
            });
        }

        internal void InternalLog(string logLevel, string content, string scope = "")
        {
            var _scope = string.IsNullOrWhiteSpace(scope) ? Scope : scope;
            var _logLevel = string.IsNullOrWhiteSpace(logLevel) ? null : LogLevels.FirstOrDefault(n => n.Name.ToLower() == logLevel.ToLower());
            var message = "";

            if (string.IsNullOrWhiteSpace(_scope))
            {
                if (_logLevel != null)
                    message = $"{_logLevel.Icon.Pastel(_logLevel.Color)} { Ansi.Underline(_logLevel.Name.Expand(BiggestLength)).Pastel(_logLevel.Color)} {content.Pastel(Color.LightGray) }";
                else
                    message = $"{"".Expand(BiggestLength + 2)} { content.Pastel(Color.Gray) }";
            }
            else
            {
                if (_logLevel != null)
                    message = $"[{_scope}]".Pastel(Color.Gray) + $" {_logLevel.Icon.Pastel(_logLevel.Color)} { Ansi.Underline(_logLevel.Name).Pastel(_logLevel.Color).Expand(BiggestLength) } {content.Pastel(Color.LightGray)}";
                else
                    message = $"[{_scope}]".Pastel(Color.Gray) + $" {"".Expand(BiggestLength + 2)} { content.Pastel(Color.LightGray) }";
            }

            foreach (var output in Outputs)
                output.WriteLine(message);
        }
    }
}