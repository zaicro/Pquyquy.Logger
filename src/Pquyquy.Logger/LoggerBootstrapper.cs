using System.Reflection;

namespace Pquyquy.Logger;

/// <summary>
/// Initializes the logger by finding and setting an implementation of the <see cref="ILogger"/> interface.
/// </summary>
public class LoggerBootstrapper
{
    /// <summary>
    /// Searches for an implementation of the <see cref="ILogger"/> interface within the loaded assemblies
    /// and sets it as the singleton instance for logging.
    /// </summary>
    /// <exception cref="Exception">
    /// Thrown when no implementation of <see cref="ILogger"/> is found, when multiple implementations are found,
    /// or when the implementation cannot be instantiated.
    /// </exception>
    public static void Initialize()
    {
        List<Assembly> allAssemblies = new List<Assembly>();
        var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
        if (path.Contains("file:"))
        {
            path = path.Remove(0, "file:\\".Length);
        }

        Directory.GetFiles(path, "*.dll").Where(x => Path.GetFileName(x).Contains("Pquyquy.Logger")).ToList().ForEach(x => allAssemblies.Add(Assembly.LoadFile(x)));

        var implementingAssemblies = allAssemblies.Where(x => x.ExportedTypes.Any(y => y.GetInterfaces().Any(z => z == typeof(ILogger)))).ToList();

        if (!implementingAssemblies.Any())
        {
            throw new Exception("No implementation detected for Logger");
        }

        if (implementingAssemblies.Count() > 1)
        {
            throw new Exception("More than 1 implementation detected for Logger");
        }

        var implementingAssembly = implementingAssemblies.First();
        var implementation = implementingAssembly.GetExportedTypes().FirstOrDefault(y => y.GetInterfaces().Any(z => z == typeof(ILogger)));
        if (implementation == null)
        {
            throw new Exception("No implementation detected for Logger inside " + implementingAssembly.FullName);
        }

        Logger.Instance = (ILogger)Activator.CreateInstance(implementation);
        Logger.Instance.Info<LoggerBootstrapper>(new Dictionary<string, object>()
        {
            { "LoggerBootrstrapper", "Logger instance created sucessfully. " + implementation.FullName + " will be used." }
        });
    }
}
