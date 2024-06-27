using log4net;
using log4net.Config;
using System.Xml;

namespace Pquyquy.Logger.Log4Net;

/// <summary>
/// Logger implementation using log4net for logging messages.
/// </summary>
public class Log4NetLogger : ILogger
{
    private enum LogLevel
    {
        Fatal,
        Error,
        Debug,
        Warn,
        Info
    }

    private readonly Func<string, bool> _messageFilterFunc;

    /// <summary>
    /// Default constructor. Configures log4net using default configuration.
    /// </summary>
    public Log4NetLogger()
    {
        XmlConfigurator.Configure();
    }

    /// <summary>
    /// Constructor with XML configuration element and message filter function.
    /// Configures log4net using provided XML configuration.
    /// </summary>
    /// <param name="xmlElement">XML element containing log4net configuration.</param>
    /// <param name="messageFilterFunc">Function to filter messages.</param>
    public Log4NetLogger(XmlElement xmlElement, Func<string, bool> messageFilterFunc)
    {
        _messageFilterFunc = messageFilterFunc;
        XmlConfigurator.Configure(xmlElement);
    }

    /// <summary>
    /// Logs an informational message.
    /// </summary>
    public void Info<T>(Dictionary<string, object> data, string thirdPartyName = "")
    {
        var log = LogManager.GetLogger(typeof(T));
        Log(log, LogLevel.Info, data, thirdPartyName);
    }

    /// <summary>
    /// Logs a debug message.
    /// </summary>
    public void Debug<T>(Dictionary<string, object> data, string thirdPartyName = "")
    {
        var log = LogManager.GetLogger(typeof(T));
        Log(log, LogLevel.Debug, data, thirdPartyName);
    }

    /// <summary>
    /// Logs an error message.
    /// </summary>
    public void Error<T>(Dictionary<string, object> data, Exception ex = null, string thirdPartyName = "")
    {
        var log = LogManager.GetLogger(typeof(T));
        Log(log, LogLevel.Error, data, thirdPartyName, ex);
    }

    /// <summary>
    /// Logs a warning message.
    /// </summary>
    public void Warn<T>(Dictionary<string, object> data, Exception ex = null, string thirdPartyName = "")
    {
        var log = LogManager.GetLogger(typeof(T));
        Log(log, LogLevel.Warn, data, thirdPartyName, ex);
    }

    /// <summary>
    /// Logs a fatal error message.
    /// </summary>
    public void Fatal<T>(Dictionary<string, object> data, Exception ex = null, string thirdPartyName = "")
    {
        var log = LogManager.GetLogger(typeof(T));
        Log(log, LogLevel.Fatal, data, thirdPartyName, ex);
    }

    /// <summary>
    /// Logs a message at a specific log level.
    /// </summary>
    private void Log(ILog log, LogLevel logLevel, Dictionary<string, object> data, string thirdPartyName, Exception exception = null)
    {
        var message = (new LogModel() { Data = data, ThirdPartyName = thirdPartyName }).ToString();

        // Apply message filter if provided
        if ((_messageFilterFunc == null || !_messageFilterFunc.Invoke(message)) && (!string.IsNullOrWhiteSpace(message) || exception != null))
        {
            LogMessageAtSpecificLevel(log, logLevel, message, exception);
        }
    }

    /// <summary>
    /// Logs a message at the specified log level using log4net.
    /// </summary>
    private static void LogMessageAtSpecificLevel(ILog log, LogLevel logLevel, string message, Exception exception = null)
    {
        switch (logLevel)
        {
            case LogLevel.Fatal:
                if (log.IsFatalEnabled) log.Fatal(message, exception);
                break;
            case LogLevel.Debug:
                if (log.IsDebugEnabled) log.Debug(message, exception);
                break;
            case LogLevel.Error:
                if (log.IsErrorEnabled) log.Error(message, exception);
                break;
            case LogLevel.Info:
                if (log.IsInfoEnabled) log.Info(message, exception);
                break;
            case LogLevel.Warn:
                if (log.IsWarnEnabled) log.Warn(message, exception);
                break;
            default:
                log.Warn($"Encountered unknown log level {logLevel}, writing out as Info.");
                log.Info(message, exception);
                break;
        }
    }
}
