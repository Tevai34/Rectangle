public class InternalNode : Node
{
    public List<Node> Children { get; set; }

    public InternalNode(int xMin, int yMin, int xMax, int yMax) : base(xMin, yMin, xMax, yMax)
    {
        Children = new List<Node>();
    }

    public override void Insert(Rectangle rect)
    {
        // Similar to LeafNode, but it will insert the rectangle into one of the child nodes.
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