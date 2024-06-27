using System.Xml;

namespace Pquyquy.Logger.Log4Net.UnitTests.Logger
{
    [TestFixture]
    public class Log4NetLoggerTests
    {
        [Test]
        public void TryInstance_NoArguments_OK()
        {
            var instance = new Log4NetLogger();
            Assert.That(instance, Is.Not.Null);
            Assert.That(instance, Is.InstanceOf(typeof(Log4NetLogger)));
        }

        [Test]
        public void TryInstance_WithArguments_OK()
        {
            var instance = new Log4NetLogger(GetXmlElement(), GetFunc("Log"));
            Assert.That(instance, Is.Not.Null);
            Assert.That(instance, Is.InstanceOf(typeof(Log4NetLogger)));
        }

        [Test]
        public void Debug()
        {
            Pquyquy.Logger.Logger.Instance.Debug<Log4NetLoggerTests>(GetData("Debug"), "ThirdPartyExample");
        }

        [Test]
        public void Info()
        {
            Pquyquy.Logger.Logger.Instance.Info<Log4NetLoggerTests>(GetData("Info"));
        }

        [Test]
        public void Warn_WithoutException_WritesLog()
        {
            Pquyquy.Logger.Logger.Instance.Warn<Log4NetLoggerTests>(GetData("Warn"), new Exception("Exception"), "ThirdPartyExample");
        }

        [Test]
        public void Warn_WithException_WritesLog()
        {
            Pquyquy.Logger.Logger.Instance.Warn<Log4NetLoggerTests>(GetData("Warn"), new Exception("Exception"), "ThirdPartyExample");
        }

        [Test]
        public void Error_WithoutException_WritesLog()
        {
            Pquyquy.Logger.Logger.Instance.Error<Log4NetLoggerTests>(GetData("Error"), new Exception("Exception"), "ThirdPartyExample");
        }

        [Test]
        public void Error_WithException_WritesLog()
        {
            Pquyquy.Logger.Logger.Instance.Error<Log4NetLoggerTests>(GetData("Error"), new Exception("Exception"), "ThirdPartyExample");
        }

        [Test]
        public void Fatal_WithoutException_WritesLog()
        {
            Pquyquy.Logger.Logger.Instance.Fatal<Log4NetLoggerTests>(GetData("Fatal"));
        }

        [Test]
        public void Fatal_WithException_WritesLog()
        {
            Pquyquy.Logger.Logger.Instance.Fatal<Log4NetLoggerTests>(GetData("Fatal"), new Exception("Exception"), string.Empty);
        }
        private Dictionary<string, object> GetData(string msg)
        {
            var result = new Dictionary<string, object>();
            result.Add("Message", msg);
            return result;
        }

        #region private methods
        private Func<string, bool> GetFunc(string msg)
        {
            var result = new Func<string, bool>(s => s.Equals(msg));
            return result;
        }

        private XmlElement GetXmlElement()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<Log Level='Warn'>" +
                        "<title>Warning</title>" +
                        "</Log>");
            return doc.CreateElement("Log");
        }
        #endregion
    }
}
