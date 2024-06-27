namespace Pquyquy.Logger.UnitTests.Test;

[TestFixture]
public class LoggerTest
{


    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Get_InstanceNull_Throws()
    {
        Logger.Instance = null;
        Assert.Throws<TypeInitializationException>(() => Logger.Instance.ToString());
    }
}