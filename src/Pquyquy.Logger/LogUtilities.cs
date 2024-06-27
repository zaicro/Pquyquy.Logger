namespace Pquyquy.Logger;

/// <summary>
/// Provides utility methods for logging purposes.
/// </summary>
public static class LogUtilities
{
    /// <summary>
    /// Formats logging data using the specified method name.
    /// </summary>
    /// <param name="methodName">The name of the method.</param>
    /// <param name="message">The log message.</param>
    /// <returns>A dictionary containing the method name and the message.</returns>
    public static Dictionary<string, object> FormatData(string methodName, string message)
    {
        return new Dictionary<string, object>
        {
            { "Method", methodName },
            { "Message", message }
        };
    }

    /// <summary>
    /// Formats data for logging purposes, including the method name and a message.
    /// </summary>
    /// <typeparam name="TMethod">The type of the method or class containing the method.</typeparam>
    /// <param name="method">The method or class instance from which the method name will be derived.</param>
    /// <param name="message">The message to be logged.</param>
    /// <returns>A dictionary containing formatted log data with "Method" and "Message" entries.</returns>
    public static Dictionary<string, object> FormatData<TMethod>(TMethod method, string message)
    {
        return new Dictionary<string, object>
        {
            { "Method", nameof(method) },
            { "Message", message }
        };
    }
}
