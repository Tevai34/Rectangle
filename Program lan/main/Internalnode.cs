public class InternalNode : Node
{
    public List<Node> Children { get; set; }

    public InternalNode(int xMin, int yMin, int xMax, int yMax) : base(xMin, yMin, xMax, yMax)
    {
        Children = new List<Node>();
    }

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

private void SplitNode()
{
    // Define the midpoint of the current space
    int midX = (XMin + XMax) / 2;
    int midY = (YMin + YMax) / 2;

    // Create four new child LeafNodes representing the quadrants
    Children = new List<Node>
    {
        new LeafNode(XMin, midX, midY, YMax),  // Top-left quadrant
        new LeafNode(midX, XMax, midY, YMax),  // Top-right quadrant
        new LeafNode(XMin, midX, YMin, midY),  // Bottom-left quadrant
        new LeafNode(midX, XMax, YMin, midY)   // Bottom-right quadrant
    };

    // distribute the existing rectangles to the correct child nodes
    foreach (var rectangle in Rectangles)
    {
        InsertIntoChildNode(rectangle);
    }

    // Clear the current list of rectangles as they have been moved to child nodes
    Rectangles.Clear();
}

private void InsertIntoChildNode(Rectangle rect)
{
    // Determine which child node (quadrant) the rectangle should go into
    Node targetChild = null;

    // Check the position of the rectangle and assign it to the appropriate child
    if (rect.XMin < (XMin + XMax) / 2 && rect.YMax >= (YMin + YMax) / 2)
    {
        targetChild = Children[0];  // Top-left quadrant
    }
    else if (rect.XMin >= (XMin + XMax) / 2 && rect.YMax >= (YMin + YMax) / 2)
    {
        targetChild = Children[1];  // Top-right quadrant
    }
    else if (rect.XMin < (XMin + XMax) / 2 && rect.YMax < (YMin + YMax) / 2)
    {
        targetChild = Children[2];  // Bottom-left quadrant
    }
    else if (rect.XMin >= (XMin + XMax) / 2 && rect.YMax < (YMin + YMax) / 2)
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


    public override void Delete(int x, int y)
    {
        foreach (var child in Children)
        {
            child.Delete(x, y);
        }
    }

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

    public override void Update(int x, int y, int length, int width)
    {
        foreach (var child in Children)
        {
            child.Update(x, y, length, width);
        }
    }

    public override void Dump(int level)
    {
        Console.WriteLine(new string('\t', level) + $"Internal Node at [{XMin},{YMin}] to [{XMax},{YMax}]");
        foreach (var child in Children)
        {
            child.Dump(level + 1);
        }
    }
}
