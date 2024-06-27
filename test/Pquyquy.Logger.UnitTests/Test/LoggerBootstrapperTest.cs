using Microsoft.Extensions.DependencyInjection;
using Pquyquy.Logger.UnitTests.Impl;

namespace Pquyquy.Logger.UnitTests.Test;

[TestFixture]
internal class LoggerBootstrapperTest
{
    [SetUp]
    public void Setup()
    {
        var services = new ServiceCollection();
        services.AddSingleton<ILogger, LoggerImplementations>();
        var _serviceProvider = services.BuildServiceProvider();
        var logger = _serviceProvider.GetService<ILogger>();
        Logger.Instance = logger;
    }

    [Test]
    public void Get_InstanceNotNull_OK()
    {
        Assert.That(Logger.Instance, Is.Not.Null);
    }
}
