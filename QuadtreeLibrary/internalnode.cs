namespace Quadtree;

/// <summary>
/// [TODO:description]
/// </summary>
public class InternalNode : Node
{
    /// <summary>
    /// [TODO:description]
    /// </summary>
    public List<Node> Children { get; set; }

    /// <summary>
    /// [TODO:description]
    /// </summary>
    /// <param name="xMin">[TODO:description]</param>
    /// <param name="yMin">[TODO:description]</param>
    /// <param name="xMax">[TODO:description]</param>
    /// <param name="yMax">[TODO:description]</param>
    public InternalNode(int xMin, int yMin, int xMax, int yMax) : base(xMin, yMin, xMax, yMax)
    {
        //NOTE: you *might* need an additional property:
        //  - threshold: The amount of rectangles that a node should hold before it splits.
        //  You may need it when you make leaf nodes for their constructor.
        Children = new List<Node>();
    }

    /// <summary>
    /// [TODO:description]
    /// </summary>
    /// <param name="rect">[TODO:description]</param>
    public override void Insert(Rectangle rect)
    {
        if (Rectangles.Count < 5)
        {
            // If the node has fewer than 5 rectangles, simply insert the new one
            Rectangles.Add(rect);
        }
        else
        {
            // Split the node into 4 child nodes 
            SplitNode();

            // Now insert the rectangle into the appropriate child node
            InsertIntoChildNode(rect);
        }
    }

    /// <summary>
    /// [TODO:description]
    /// </summary>
    private void SplitNode()
    {
        // Define the midpoint of the current space
        int midX = (xMin + xMax) / 2;
        int midY = (yMin + yMax) / 2;

        // Create four new child LeafNodes representing the quadrants
        Children = new List<Node>
    {
        new LeafNode(xMin, midX, midY, yMax),  // Top-left quadrant
        new LeafNode(midX, xMax, midY, yMax),  // Top-right quadrant
        new LeafNode(xMin, midX, yMin, midY),  // Bottom-left quadrant
        new LeafNode(midX, xMax, yMin, midY)   // Bottom-right quadrant
    };

        // distribute the existing rectangles to the correct child nodes
        foreach (var rectangle in Rectangles)
        {
            InsertIntoChildNode(rectangle);
        }

        // Clear the current list of rectangles as they have been moved to child nodes
        Rectangles.Clear();
    }

    /// <summary>
    /// [TODO:description]
    /// </summary>
    /// <param name="rect">[TODO:description]</param>
    private void InsertIntoChildNode(Rectangle rect)
    {
        // Determine which child node (quadrant) the rectangle should go into
        Node targetChild = null;

        // Check the position of the rectangle and assign it to the appropriate child
        if (rect.x < (xMin + xMax) / 2 && rect.y >= (yMin + yMax) / 2)
        {
            targetChild = Children[0];  // Top-left quadrant
        }
        else if (rect.x >= (xMin + xMax) / 2 && rect.y >= (yMin + yMax) / 2)
        {
            targetChild = Children[1];  // Top-right quadrant
        }
        else if (rect.x < (xMin + xMax) / 2 && rect.y < (yMin + yMax) / 2)
        {
            targetChild = Children[2];  // Bottom-left quadrant
        }
        else if (rect.x >= (xMin + xMax) / 2 && rect.y < (yMin + yMax) / 2)
        {
            targetChild = Children[3];  // Bottom-right quadrant
        }

        // Insert the rectangle into the target child node
        if (targetChild is LeafNode leafNode)
        {
            leafNode.Insert(rect);
        }
        else if (targetChild is InternalNode internalNode)
        {
            internalNode.Insert(rect);
        }
    }


    /// <summary>
    /// [TODO:description]
    /// </summary>
    /// <param name="x">[TODO:description]</param>
    /// <param name="y">[TODO:description]</param>
    public override void Delete(int x, int y)
    {
        foreach (var child in Children)
        {
            child.Delete(x, y);
        }
    }

    /// <summary>
    /// [TODO:description]
    /// </summary>
    /// <param name="x">[TODO:description]</param>
    /// <param name="y">[TODO:description]</param>
    /// <returns>[TODO:description]</returns>
    public override Rectangle Find(int x, int y)
    {
        foreach (var child in Children)
        {
            var rect = child.Find(x, y);
            if (rect != null)
                return rect;
        }
        return null;
    }

    /// <summary>
    /// [TODO:description]
    /// </summary>
    /// <param name="x">[TODO:description]</param>
    /// <param name="y">[TODO:description]</param>
    /// <param name="length">[TODO:description]</param>
    /// <param name="width">[TODO:description]</param>
    public override void Update(int x, int y, int length, int width)
    {
        foreach (var child in Children)
        {
            child.Update(x, y, length, width);
        }
    }

    /// <summary>
    /// [TODO:description]
    /// </summary>
    /// <param name="level">[TODO:description]</param>
    public override void Dump(int level)
    {
        Console.WriteLine(new string('\t', level) + $"Internal Node at [{xMin},{yMin}] to [{xMax},{yMax}]");
        foreach (var child in Children)
        {
            child.Dump(level + 1);
        }
    }
}
