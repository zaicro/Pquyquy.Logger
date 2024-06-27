using System.Text;

namespace Pquyquy.Logger.Log4Net;

/// <summary>
/// Represents a model for logging data with an optional third-party name.
/// </summary>
public class LogModel
{
    /// <summary>
    /// Gets or sets the data dictionary for logging.
    /// </summary>
    public Dictionary<string, object> Data { get; set; } = new Dictionary<string, object>();

    /// <summary>
    /// Gets or sets the optional third-party name associated with the log.
    /// </summary>
    public string ThirdPartyName { get; set; }

    /// <summary>
    /// Customizes the ToString method to format the log output.
    /// </summary>
    /// <returns>A formatted string representation of the log data.</returns>
    public override string ToString()
    {
        var sb = new StringBuilder();

        // Append message if present
        if (Data.TryGetValue("Message", out object message) && !string.IsNullOrEmpty(message?.ToString()))
        {
            sb.Append($"Message: {message}\n");
            Data.Remove("Message");
        }
        else
        {
            sb.Append($"Message: \n");
        }

        // Append data entries
        sb.Append(ProcessData("Data", Data));

        // Append third-party name if present
        sb.Append(ProcessThirdPartyName("Third-party name", ThirdPartyName));

        return sb.ToString();
    }

    /// <summary>
    /// Processes the data dictionary entries into a formatted string.
    /// </summary>
    /// <param name="name">Name of the data section.</param>
    /// <param name="data">Data dictionary to process.</param>
    /// <returns>Formatted string representation of the data.</returns>
    private static string ProcessData(string name, Dictionary<string, object> data)
    {
        if (data == null || data.Count == 0)
        {
            return string.Empty;
        }

        var sb = new StringBuilder();

        foreach (var kvp in data)
        {
            sb.Append($"{name}.{kvp.Key}: {FormatValue(kvp.Value)}\n");
        }

        return sb.ToString();
    }

    /// <summary>
    /// Processes the optional third-party name into a formatted string.
    /// </summary>
    /// <param name="name">Name of the third-party section.</param>
    /// <param name="thirdParty">Third-party name to process.</param>
    /// <returns>Formatted string representation of the third-party name.</returns>
    private static string ProcessThirdPartyName(string name, string thirdParty)
    {
        if (string.IsNullOrEmpty(thirdParty))
        {
            return string.Empty;
        }

        return $"{name}: {thirdParty}\n";
    }

    /// <summary>
    /// Formats the value into a string representation.
    /// </summary>
    /// <param name="value">Value to format.</param>
    /// <returns>Formatted string representation of the value.</returns>
    private static string FormatValue(object value)
    {
        if (value == null)
        {
            return "null";
        }
        else if (value is Dictionary<string, object> dictionary)
        {
            var sb = new StringBuilder();
            sb.AppendLine("{");
            foreach (var kvp in dictionary)
            {
                sb.AppendLine($"  {kvp.Key}: {FormatValue(kvp.Value)}");
            }
            sb.Append("}");
            return sb.ToString();
        }
        else
        {
            return value.ToString();
        }
    }
}
