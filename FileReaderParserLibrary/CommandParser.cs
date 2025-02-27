using System;
using System.Collections.Generic;
using System.IO;

namespace FileReaderParserLibrary
{
    /// The CommandParser class is responsible for reading a file and parsing its content
    /// into a list of command strings. Each command is expected to be on a separate line.
    public class CommandParser
    {
        
        /// Parses a file and extracts each non-empty line as a command.
        /// Lines with only whitespace are ignored. The resulting list
        /// contains the commands as strings.
    
        ///The file path of the text file to be parsed.
        public List<string> ParseCommands(string filePath)
        {
            // A list to store the parsed commands.
            var commands = new List<string>(); 
            try
            {
                // Read all lines from the specified file.
                var lines = File.ReadAllLines(filePath);
                
                foreach (var line in lines)
                {
                    // Add the line to the command list after trimming any leading/trailing whitespace.
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        commands.Add(line.Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                // Catch any exception that occurs while reading the file and log the error message.
                Console.WriteLine($"Error reading file: {ex.Message}");
            }

            // Return the list of parsed commands.
            return commands;
        }
    }
}
