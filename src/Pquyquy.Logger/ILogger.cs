namespace Pquyquy.Logger;

/// <summary>
/// Provides logging functionality with various severity levels.
/// </summary>
public interface ILogger
{
    /// <summary>
    /// Logs an informational message.
    /// </summary>
    /// <typeparam name="T">The type of the source of the log message.</typeparam>
    /// <param name="data">The data to log.</param>
    /// <param name="source">The name of the third-party source, if any.</param>
    public void Info<T>(Dictionary<string, object> data, string source = "");

    /// <summary>
    /// Logs a debug message.
    /// </summary>
    /// <typeparam name="T">The type of the source of the log message.</typeparam>
    /// <param name="data">The data to log.</param>
    /// <param name="source">The name of the third-party source, if any.</param>
    public void Debug<T>(Dictionary<string, object> data, string source = "");

    /// <summary>
    /// Logs an error message.
    /// </summary>
    /// <typeparam name="T">The type of the source of the log message.</typeparam>
    /// <param name="data">The data to log.</param>
    /// <param name="exception">The exception to log, if any.</param>
    /// <param name="source">The name of the third-party source, if any.</param>
    public void Error<T>(Dictionary<string, object> data, Exception exception = null, string source = "");

    /// <summary>
    /// Logs a warning message.
    /// </summary>
    /// <typeparam name="T">The type of the source of the log message.</typeparam>
    /// <param name="data">The data to log.</param>
    /// <param name="exception">The exception to log, if any.</param>
    /// <param name="source">The name of the third-party source, if any.</param>
    public void Warn<T>(Dictionary<string, object> data, Exception exception = null, string source = "");

    /// <summary>
    /// Logs a fatal error message.
    /// </summary>
    /// <typeparam name="T">The type of the source of the log message.</typeparam>
    /// <param name="data">The data to log.</param>
    /// <param name="exception">The exception to log, if any.</param>
    /// <param name="source">The name of the third-party source, if any.</param>
    public void Fatal<T>(Dictionary<string, object> data, Exception exception = null, string source = "");
}
