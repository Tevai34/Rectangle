public abstract class Node
{
    public List<Rectangle> Rectangles { get; set; }
    public int XMin { get; set; }
    public int YMin { get; set; }
    public int XMax { get; set; }
    public int YMax { get; set; }

    public Node(int xMin, int yMin, int xMax, int yMax)
    {
        Rectangles = new List<Rectangle>();
        XMin = xMin;
        YMin = yMin;
        XMax = xMax;
        YMax = yMax;
    }

    public abstract void Insert(Rectangle rect);
    public abstract void Delete(int x, int y);
    public abstract Rectangle Find(int x, int y);
    public abstract void Update(int x, int y, int length, int width);
    public abstract void Dump(int level);
}

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

public class Rectangle
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Length { get; set; }
    public int Width { get; set; }

    public Rectangle(int x, int y, int length, int width)
    {
        X = x;
        Y = y;
        Length = length;
        Width = width;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Parse the .cmmd file, process each command.
        // Initialize the quadtree, e.g., create a root LeafNode with the initial space.
    }
}

public class QuadtreeTests
{
    [Fact]
    public void TestInsertRectangle()
    {
        var quadtree = new Quadtree();
        var rect = new Rectangle(10, 10, 5, 5);
        quadtree.Insert(rect);

        var foundRect = quadtree.Find(10, 10);
        Assert.Equal(rect, foundRect);
    }

    [Fact]
    public void TestDeleteRectangle()
    {
        var quadtree = new Quadtree();
        var rect = new Rectangle(10, 10, 5, 5);
        quadtree.Insert(rect);

        quadtree.Delete(10, 10);
        var foundRect = quadtree.Find(10, 10);
        Assert.Null(foundRect);
    }
}
