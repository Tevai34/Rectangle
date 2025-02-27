namespace Quadtree;

/// A class representing an internal node in the quadtree. This node contains child nodes,
/// and is responsible for splitting when the number of rectangles exceeds the threshold.
public class InternalNode : Node
{
    public List<Node> Children { get; set; }
    private int threshold;

    /// Initializes a new instance of the InternalNode class with given space and threshold.
    /// The minimum x-coordinate of the node's space.
    /// The minimum y-coordinate of the node's space.
    /// The maximum x-coordinate of the node's space.
    /// The maximum y-coordinate of the node's space.
    /// The threshold for the number of rectangles before splitting.
    public InternalNode(int xMin, int yMin, int xMax, int yMax, int threshold) : base(xMin, yMin, xMax, yMax)
    {
        this.threshold = threshold;
        this.Children = new List<Node>();
    }

    /// Inserts a rectangle into the node. If the node exceeds the threshold, it splits into child nodes.
    /// The rectangle to insert into the node.
    public override void Insert(Rectangle rect)
    {
        if (Rectangles.Count < threshold)
        {
            // If the node has fewer than the threshold, insert the rectangle directly
            Rectangles.Add(rect);
        }
        else
        {
            // Split the node into 4 child nodes if it exceeds the threshold
            SplitNode();
            
            // Now insert the rectangle into the appropriate child node
            InsertIntoChildNode(rect);
        }
    }

    /// Splits the node into 4 quadrants (child nodes) when the threshold is exceeded.
    private void SplitNode()
    {
        // Define the midpoint of the current space
        int midX = (xMin + xMax) / 2;
        int midY = (yMin + yMax) / 2;

        // Create four new child LeafNodes representing the quadrants
        Children = new List<Node>
        {
            // Top-left quadrant
            new LeafNode(threshold, new Rectangle(xMin, midY, midX, yMax)),
            // Top-right quadrant
            new LeafNode(threshold, new Rectangle(midX, midY, xMax, yMax)),
            // Bottom-left quadrant
            new LeafNode(threshold, new Rectangle(xMin, yMin, midX, midY)),
            // Bottom-right quadrant
            new LeafNode(threshold, new Rectangle(midX, yMin, xMax, midY))   
        };

        // Distribute the existing rectangles to the correct child nodes
        foreach (var rectangle in Rectangles)
        {
            InsertIntoChildNode(rectangle);
        }

        // Clear the current list of rectangles as they have been moved to child nodes
        Rectangles.Clear();
    }

    /// Inserts a rectangle into the appropriate child node based on its position.
    /// The rectangle to insert into the child node.
    private void InsertIntoChildNode(Rectangle rect)
    {
        Node targetChild = null;

        // Determine which quadrant the rectangle belongs to and assign it to the correct child node
        if (rect.x < (xMin + xMax) / 2 && rect.y >= (yMin + yMax) / 2)
        {
            // Top-left quadrant
            targetChild = Children[0];  
        }
        else if (rect.x >= (xMin + xMax) / 2 && rect.y >= (yMin + yMax) / 2)
        {
            // Top-right quadrant
            targetChild = Children[1];  
        }
        else if (rect.x < (xMin + xMax) / 2 && rect.y < (yMin + yMax) / 2)
        {
            // Bottom-left quadrant
            targetChild = Children[2];  
        }
        else if (rect.x >= (xMin + xMax) / 2 && rect.y < (yMin + yMax) / 2)
        {
            // Bottom-right quadrant
            targetChild = Children[3];  
        }

        // Insert the rectangle into the target child node (either LeafNode or InternalNode)
        if (targetChild is LeafNode leafNode)
        {
            leafNode.Insert(rect);
        }
        else if (targetChild is InternalNode internalNode)
        {
            internalNode.Insert(rect);
        }
    }

    /// Deletes a rectangle based on its coordinates from the node.
    public override void Delete(int x, int y)
    {
        /// The x-coordinate of the rectangle to delete.
        /// The y-coordinate of the rectangle to delete.
        foreach (var child in Children)
        {
            child.Delete(x, y);
        }
    }

    /// Finds a rectangle based on its coordinates in the node's children.
    public override Rectangle Find(int x, int y)
    {
        foreach (var child in Children)
        {
            /// The x-coordinate of the rectangle to find.
            /// The y-coordinate of the rectangle to find.
            var rect = child.Find(x, y);
            if (rect != null)
                return rect;
        }
        /// The rectangle found, or null if not found.
        return null;
    }

    /// Updates the dimensions of a rectangle in the node.
    /// The x-coordinate of the rectangle to update.
    /// The y-coordinate of the rectangle to update.
    public override void Update(int x, int y, int length, int width)
    {
        foreach (var child in Children)
        {
            /// The new length of the rectangle.
            /// The new width of the rectangle.
            child.Update(x, y, length, width);
        }
    }

    /// Dumps the structure of the internal node and its children.
    public override void Dump(int level)
    {
        Console.WriteLine(new string('\t', level) + $"Internal Node at [{xMin},{yMin}] to [{xMax},{yMax}]");
        foreach (var child in Children)
        {
            /// The depth level for indentation in the dump output.
            child.Dump(level + 1);
        }
    }
}
