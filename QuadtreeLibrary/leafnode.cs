namespace Quadtree;

/// <summary>
/// [TODO:description]
/// </summary>
public class LeafNode : Node
{
    /// <summary>
    /// [TODO:description]
    /// </summary>
    /// <param name="xMin">[TODO:description]</param>
    /// <param name="yMin">[TODO:description]</param>
    /// <param name="xMax">[TODO:description]</param>
    /// <param name="yMax">[TODO:description]</param>
    public LeafNode(int xMin, int yMin, int xMax, int yMax) : base(xMin, yMin, xMax, yMax)
    {
        //NOTE: you'll need two properties:
        //  - threshold: The amount of rectangles that a node should hold before it splits.
        //  - data: a list/array of the rectangles contained by the node.
    }

    /// <summary>
    /// [TODO:description]
    /// </summary>
    /// <param name="rect">[TODO:description]</param>
    public override void Insert(Rectangle rect)
    {
        if (Rectangles.Count < 5)
        {
            // If the node is not full, insert the rectangle directly
            Rectangles.Add(rect);
        }
        else
        {
            // If the node is full, we need to split it and redistribute rectangles
            SplitNode();

            // After splitting, insert the rectangle into the appropriate child node
            InsertIntoChildNode(rect);
        }
    }

    /// <summary>
    /// [TODO:description]
    /// </summary>
    /// <param name="x">[TODO:description]</param>
    /// <param name="y">[TODO:description]</param>
    public override void Delete(int x, int y)
    {
        var rect = Rectangles.FirstOrDefault(r => r.x == x && r.y == y);
        if (rect != null)
        {
            Rectangles.Remove(rect);
        }
    }

    /// <summary>
    /// [TODO:description]
    /// </summary>
    /// <param name="level">[TODO:description]</param>
    public override void Dump(int level)
    {
        foreach (var rect in Rectangles)
        {
            Console.WriteLine(new string('\t', level) + $"Rectangle at {rect.x}, {rect.y}: {rect.length}x{rect.width}");
        }
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
        var rect = Rectangles.FirstOrDefault(r => r.y == x && r.y == y);
        if (rect != null)
        {
            rect.length = length;
            rect.width = width;
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
        return Rectangles.FirstOrDefault(r => r.x == x && r.y == y);
    }

    /// <summary>
    /// [TODO:description]
    /// </summary>
    private void SplitNode()
    {
        // Calculate the midpoint of the current node space
        int midX = (xMin + xMax) / 2;
        int midY = (yMin + yMax) / 2;

        // Create four child nodes representing the four quadrants of the current node's space
        List<Node> children = new List<Node>
        {
            new LeafNode(xMin, midY, midX, yMax),  // Top-left
            new LeafNode(midX, midY, xMax, yMax),  // Top-right
            new LeafNode(xMin, yMin, midX, midY),  // Bottom-left
            new LeafNode(midX, yMin, xMax, midY)   // Bottom-right
        };

        // Redistribute existing rectangles to the child nodes based on their positions
        foreach (var rect in Rectangles)
        {
            InsertIntoChildNode(rect);
        }

        // Clear the current node's rectangles as they've been moved to the children
        Rectangles.Clear();
    }

    private void InsertIntoChildNode(Rectangle rect)
    {
        // NOTE: I'm not going to fix or advise on this because leafnodes should not have 
        // children, and as a result, this method should be deleted.

        /*
        // Determine which child node (quadrant) the rectangle should go into
         Node targetChild = null;

        // Check the position of the rectangle and assign it to the correct child node
        if (rect.xMin < (XMin + XMax) / 2 && rect.YMax >= (YMin + YMax) / 2)
        {
            targetChild = children[0];  // Top-left quadrant
        }
        else if (rect.XMin >= (XMin + XMax) / 2 && rect.YMax >= (YMin + YMax) / 2)
        {
            targetChild = Children[1];  // Top-right quadrant
        }
        else if (rect.XMin < (XMin + XMax) / 2 && rect.YMax < (YMin + YMax) / 2)
        {
            targe
        */
    }
}
