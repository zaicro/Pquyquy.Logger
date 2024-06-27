namespace Pquyquy.Logger.Log4Net.UnitTests;

[SetUpFixture]
public class SetUpTests
{
    [OneTimeSetUp]
    public void SetUp()
    {
        LoggerBootstrapper.Initialize();
    }
}