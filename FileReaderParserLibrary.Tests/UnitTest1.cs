using System.IO;
using FileReaderParserLibrary;
using Xunit;

namespace FileReaderParserLibrary.Tests
{
public class FileReaderTests
    {
        [Fact]
        public void TestFileReader_ReadsCorrectContent()
        {
            // Arrange: Create expected content and path to the test file
            var expectedContent = "Hello, world!";
            var filePath = "testfile.txt";

            // Create a temporary file with the expected content
            File.WriteAllText(filePath, expectedContent);  // Writing to the file system

            // Create an instance of the FileReader class
            var fileReader = new FileReader();

            // Act: Call the method that reads the file
            var actualContent = fileReader.ReadFile(filePath);

            // Assert: Verify the actual content matches the expected content
            Assert.Equal(expectedContent, actualContent);

            // Clean up: Delete the test file after the test
            File.Delete(filePath);
        }

        [Fact]
        public void TestFileReader_ThrowsFileNotFoundException_ForNonExistentFile()
        {
            // Arrange
            var filePath = "nonexistentfile.txt";
            var fileReader = new FileReader();

            // Act & Assert: Ensure a FileNotFoundException is thrown
            Assert.Throws<FileNotFoundException>(() => fileReader.ReadFile(filePath));
        }
    }
}


