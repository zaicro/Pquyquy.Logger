namespace Pquyquy.Logger;

/// <summary>
/// Provides a static accessor for a logger instance.
/// </summary>
public static class Logger
{
    private static ILogger instance;

    /// <summary>
    /// Gets or sets the singleton instance of the logger.
    /// </summary>
    /// <exception cref="TypeInitializationException">Thrown when trying to get an instance that has not been set.</exception>
    public static ILogger Instance
    {
        get
        {
            if (instance == null)
            {
                throw new TypeInitializationException("Pquyquy.Logger.Logger", new Exception("No instance has been specified"));
            }
            return instance;
        }
        set
        {
            instance = value;
        }
    }
}