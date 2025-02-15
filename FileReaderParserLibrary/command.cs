namespace FileReaderParserLibrary;

/// <summary>
/// [TODO:description]
/// </summary>
public class CommandParser
{
    /// <summary>
    /// [TODO:description]
    /// </summary>
    /// <param name="filePath">[TODO:description]</param>
    /// <returns>[TODO:description]</returns>
    public List<string> ParseCommands(string filePath)
    {
        var commands = new List<string>();
        try
        {
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    commands.Add(line.Trim());
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }

        return commands;
    }
}
