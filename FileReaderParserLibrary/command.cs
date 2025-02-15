namespace FileReaderParserLibrary;

public class CommandParser
{
    // Method to read and parse the file containing commands
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
