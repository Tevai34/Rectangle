public class LeafNode : Node
{
    public LeafNode(int xMin, int yMin, int xMax, int yMax) : base(xMin, yMin, xMax, yMax) { }

    public override void Insert(Rectangle rect)
    {
        if (Rectangles.Count < 5)
        {
            Rectangles.Add(rect);
        }
        else
        {
            // Split the node and move existing rectangles into new leaf nodes
            // Create child nodes and distribute rectangles accordingly.
        }
    }

    public override void Delete(int x, int y)
    {
        var rect = Rectangles.FirstOrDefault(r => r.X == x && r.Y == y);
        if (rect != null)
        {
            Rectangles.Remove(rect);
        }
    }

    public override Rectangle Find(int x, int y)
    {
        return Rectangles.FirstOrDefault(r => r.X == x && r.Y == y);
    }

    public override void Update(int x, int y, int length, int width)
    {
        var rect = Rectangles.FirstOrDefault(r => r.X == x && r.Y == y);
        if (rect != null)
        {
            rect.Length = length;
            rect.Width = width;
        }
    }

    public override void Dump(int level)
    {
        foreach (var rect in Rectangles)
        {
            Console.WriteLine(new string('\t', level) + $"Rectangle at {rect.X}, {rect.Y}: {rect.Length}x{rect.Width}");
        }
    }
}