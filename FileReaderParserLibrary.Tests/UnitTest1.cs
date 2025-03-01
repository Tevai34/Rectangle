namespace FileReaderParserLibrary.Tests;

using System;
using System.IO;
using Xunit;

/// <summary>
/// Unit tests for the <see cref="FileReader"/> class.
/// </summary>
public class FileReaderTests
{
    /// <summary>
    /// Tests if the <see cref="FileReader.ReadFile"/> method correctly reads a file's content.
    /// </summary>
    [Fact]
    public void TestFileReader_ReadsCorrectContent()
    {
        // Arrange
        var expectedContent = "Hello, world!";
        var filePath = "testfile.txt";

        File.WriteAllText(filePath, expectedContent);

        var fileReader = new FileReader();

        // Act
        var actualContent = fileReader.ReadFile(filePath);

        // Assert
        Assert.Equal(expectedContent, actualContent);

        // Clean up
        File.Delete(filePath);
    }

    /// <summary>
    /// Tests if the <see cref="FileReader.ReadFile"/> method throws a <see cref="FileNotFoundException"/>
    /// when attempting to read a non-existent file.
    /// </summary>
    [Fact]
    public void TestFileReader_ThrowsFileNotFoundException_ForNonExistentFile()
    {
        // Arrange
        var filePath = "nonexistentfile.txt";
        var fileReader = new FileReader();

        // Act & Assert
        Assert.Throws<FileNotFoundException>(() => fileReader.ReadFile(filePath));
    }
}



