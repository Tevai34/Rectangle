namespace Quadtree;

/// A class representing a leaf node in the quadtree. This node holds the rectangles
/// and handles insertion, deletion, and updates until it splits into sub-nodes when the threshold is exceeded.
public class LeafNode : Node
{
    // Threshold for the number of rectangles before splitting
    private int threshold; 

 
    /// Initializes a new instance of the LeafNode class with a given space and threshold.
    /// The minimum x-coordinate of the node's space.
    /// The minimum y-coordinate of the node's space.
    /// The maximum x-coordinate of the node's space.
    /// The maximum y-coordinate of the node's space.
  public LeafNode(int threshold, Rectangle space) 
    : base(space.x, space.y, space.x + space.length, space.y + space.width) 
{
    this.threshold = threshold;
    this.Rectangles = new List<Rectangle>();
}



    /// Inserts a rectangle into the node. If the node exceeds the threshold, it will split into sub-nodes.
    /// The rectangle to insert into the node.
    public override void Insert(Rectangle rect)
    {
        if (Rectangles.Count < threshold)
        {
            // If the node is not full, insert the rectangle directly
            Rectangles.Add(rect);
        }
        else
        {
            // If the node is full, we should notify the parent node to handle the split
            // This is where you would call the parent node's split function, but we don't do this here
            Console.WriteLine("Node exceeds threshold, should handle split logic outside of LeafNode.");
        }
    }

    /// Deletes a rectangle based on its coordinates from the node.
    /// The x-coordinate of the rectangle to delete.
    /// The y-coordinate of the rectangle to delete.
    public override void Delete(int x, int y)
    {
        var rect = Rectangles.FirstOrDefault(r => r.x == x && r.y == y);
        if (rect != null)
        {
            Rectangles.Remove(rect);
            Console.WriteLine($"Rectangle at ({x}, {y}) deleted.");
        }
        else{
            Console.WriteLine($"No rectangle found at ({x}, {y}) to delete.");
        }
    }

    public void Delete(Rectangle rect)
{
    // Call the existing Delete method
    Delete(rect.x, rect.y); 
}



    /// Dumps the list of rectangles in the current node.
    ///The current depth level of the node, used for indentation in output.
    public override void Dump(int level)
    {Console.WriteLine(new string('\t', level) + $"Leaf Node at [{xMin},{yMin}] to [{xMax},{yMax}]");
        foreach (var rect in Rectangles)
        {
            Console.WriteLine(new string('\t', level) + $"Rectangle at {rect.x}, {rect.y}: {rect.length}x{rect.width}");
        }
    }

    /// Updates the dimensions of a rectangle in the node.
    /// The x-coordinate of the rectangle to update.
    /// The y-coordinate of the rectangle to update.
    public override void Update(int x, int y, int length, int width)
    {
        var rect = Rectangles.FirstOrDefault(r => r.x == x && r.y == y);
        if (rect != null)
        {
            /// The new length of the rectangle.
            rect.length = length;
            /// The new width of the rectangle.
            rect.width = width;
            Console.WriteLine($"Updated rectangle at ({x}, {y}) to {length}x{width}.");
        }
        else{
            Console.WriteLine($"No rectangle found at ({x}, {y}) to update.");
        }
    }

/// Finds a rectangle by its coordinates in the current node. 
/// The x-coordinate of the rectangle to find.
/// The y-coordinate of the rectangle to find.
    public override Rectangle Find(int x, int y)
    {
        ///The found rectangle, or null if no rectangle exists at the given coordinates
        return Rectangles.FirstOrDefault(r => r.x == x && r.y == y);
    }
}
