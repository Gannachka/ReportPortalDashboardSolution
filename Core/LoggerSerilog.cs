using OpenQA.Selenium;
using Serilog;
using Serilog.Events;

namespace Core
{
    public static class LoggerSerilog
    {
        public static ILogger Logger { get; set; }

        public static void Debug(string messageTempplate)
        {
            Logger.Write(LogEventLevel.Debug, messageTempplate);
        }
        public static void Debug(string messageTempplate, string text)
        {
            Logger.Write(LogEventLevel.Debug, messageTempplate, text);
        }

        public static void Information(string messageTemplate)
        {
            Logger.Write(LogEventLevel.Information, messageTemplate);
        }
        public static void Information(string messageTemplate, string text)
        {
            Logger.Write(LogEventLevel.Information, messageTemplate, text);
        }
        public static void Information(string messageTempplate, By by)
        {
            Logger.Write(LogEventLevel.Information, messageTempplate, by);
        }

        public static void Error(string messageTemplate)
        {
            Logger.Write(LogEventLevel.Error, messageTemplate);
        }

        public static void Error(string messageTemplate, By by)
        {
            Logger.Write(LogEventLevel.Error, messageTemplate, by);
        }

        public static void Fatal(string messageTemplate)
        {
            Logger.Write(LogEventLevel.Fatal, messageTemplate);
        }
        public static void Fatal(string messageTemplate, object[] obj)
        {
            Logger.Write(LogEventLevel.Fatal, messageTemplate, obj);
        }

        public static void Warning(string messageTemplate)
        {
            Logger.Write(LogEventLevel.Warning, messageTemplate);
        }
        public static void Warning(string messageTemplate, object[] obj)
        {
            Logger.Write(LogEventLevel.Warning, messageTemplate, obj);
        }
    }
}
