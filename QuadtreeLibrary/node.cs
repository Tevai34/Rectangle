namespace Quadtree;

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
