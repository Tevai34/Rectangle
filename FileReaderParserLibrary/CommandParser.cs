namespace FileReaderParserLibrary;

using System;
using System.Collections.Generic;
using System.IO;

/// The <see cref="CommandParser"/> class is responsible for reading a file and parsing its content
/// into a list of command strings. Each command is expected to be on a separate line.
public class CommandParser
{
    /// <summary>
    /// Parses a file and extracts each non-empty line as a command.
    /// Lines with only whitespace are ignored.
    /// </summary>
    /// <param name="filePath">The file path of the text file to be parsed.</param>
    /// <returns>A list of parsed commands as strings.</returns>
    public static List<string> ParseCommands(string filePath)
    {
        var commands = new List<string>();

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Error: File '{filePath}' not found.");
            return commands;
        }

        try
        {
            foreach (var line in File.ReadLines(filePath))
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    string cleanLine = line.Trim().TrimEnd(';');
                    commands.Add(cleanLine);
                }
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Error: Access to the file is denied.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"I/O Error reading file: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }

        return commands;
    }
}




