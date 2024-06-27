namespace Pquyquy.Logger.UnitTests.Impl;

internal class LoggerImplementations : ILogger
{
    public void Debug<T>(Dictionary<string, object> data, string thirdPartyName = "")
    {
        //test implmentation
    }

    public void Error<T>(Dictionary<string, object> data, Exception ex = null, string thirdPartyName = "")
    {
        //test implmentation
    }

    public void Fatal<T>(Dictionary<string, object> data, Exception ex = null, string thirdPartyName = "")
    {
        //test implmentation
    }

    public void Info<T>(Dictionary<string, object> data, string thirdPartyName = "")
    {
        //test implmentation
    }

    public void Warn<T>(Dictionary<string, object> data, Exception ex = null, string thirdPartyName = "")
    {
        //test implmentation
    }
}
