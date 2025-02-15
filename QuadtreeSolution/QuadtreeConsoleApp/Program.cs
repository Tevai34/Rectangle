using System;
using FileReaderParserLibrary;
using QuadtreeLibrary;
// Validate the command-line argument
if (args.Length != 1)
{
    Console.WriteLine("Please provide the path to the .cmmd file.");
    return;
}

string filePath = args[0];

// Parse the commands from the file
var commandParser = new commandParser();
var commands = commandParser.ParseCommands(filePath);

// Initialize a quadtree with the initial space (100x100, centered at (0, 0))
var initialSpace = new Rectangle(-50, -50, 100, 100); // The root space of the quadtree
var quadtree = new LeafNode(5, initialSpace); // Threshold of 5 rectangles before split

// Process each command from the file
foreach (var command in commands)
{
    var commandParts = command.Split(' ');
    var action = commandParts[0].ToLower();

    switch (action)
    {
        case "insert":
            if (commandParts.Length == 5)
            {
                int x = int.Parse(commandParts[1]);
                int y = int.Parse(commandParts[2]);
                int width = int.Parse(commandParts[3]);
                int height = int.Parse(commandParts[4]);

                var rect = new Rectangle(x, y, width, height);
                quadtree.Insert(rect); // Insert the rectangle into the quadtree
            }
            else
            {
                Console.WriteLine("Invalid Insert command format.");
            }
            break;

        case "delete":
            if (commandParts.Length == 3)
            {
                int x = int.Parse(commandParts[1]);
                int y = int.Parse(commandParts[2]);

                var rect = quadtree.Find(x, y); // Find the rectangle by its coordinates
                if (rect != null)
                {
                    quadtree.Delete(rect); // Delete the rectangle
                }
                else
                {
                    Console.WriteLine($"Nothing to delete at {x}, {y}.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Delete command format.");
            }
            break;

        case "find":
            if (commandParts.Length == 3)
            {
                int x = int.Parse(commandParts[1]);
                int y = int.Parse(commandParts[2]);

                var rect = quadtree.Find(x, y); // Find the rectangle
                if (rect != null)
                {
                    Console.WriteLine($"Rectangle at {x}, {y}: {rect.Width}x{rect.Height}");
                }
                else
                {
                    Console.WriteLine($"Nothing is at {x}, {y}.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Find command format.");
            }
            break;

        case "update":
            if (commandParts.Length == 5)
            {
                int x = int.Parse(commandParts[1]);
                int y = int.Parse(commandParts[2]);
                int newWidth = int.Parse(commandParts[3]);
                int newHeight = int.Parse(commandParts[4]);

                var rect = quadtree.Find(x, y); // Find the rectangle
                if (rect != null)
                {
                    quadtree.Update(x, y, newWidth, newHeight); // Update the rectangle
                }
                else
                {
                    Console.WriteLine($"Nothing to update at {x}, {y}.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Update command format.");
            }
            break;

        case "dump":
            quadtree.Dump(0); // Dump the entire quadtree structure
            break;

        default:
            Console.WriteLine($"Unknown command: {action}");
            break;
    }
}
