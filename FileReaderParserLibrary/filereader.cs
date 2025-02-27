namespace FileReaderParserLibrary;
using System.IO;

    /// A class for reading content from a file.
    public class FileReader
    {

        /// Reads the entire content of the specified file.
        /// The path of the file to read.
        /// A string containing the content of the file.
        public string ReadFile(string filePath)
        {
            // Check if the file exists
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The specified file was not found.", filePath);
            }

            // Read all text from the file and return it
            return File.ReadAllText(filePath);
        }
    }
