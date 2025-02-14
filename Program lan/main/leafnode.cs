public class LeafNode : Node
{
    public LeafNode(int xMin, int yMin, int xMax, int yMax) : base(xMin, yMin, xMax, yMax) { }

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

    private void SplitNode()
    {
        // Calculate the midpoint of the current node space
        int midX = (XMin + XMax) / 2;
        int midY = (YMin + YMax) / 2;

        // Create four child nodes representing the four quadrants of the current node's space
        Children = new List<Node>
        {
            new LeafNode(XMin, midY, midX, YMax),  // Top-left
            new LeafNode(midX, midY, XMax, YMax),  // Top-right
            new LeafNode(XMin, YMin, midX, midY),  // Bottom-left
            new LeafNode(midX, YMin, XMax, midY)   // Bottom-right
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
        // Determine which child node (quadrant) the rectangle should go into
        Node targetChild = null;

        // Check the position of the rectangle and assign it to the correct child node
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
            targe
