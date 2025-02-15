namespace Quadtree;

/// <summary>
/// [TODO:description]
/// </summary>
public abstract class Node
{
    //NOTE: you should delete this. Only the leaf node has rectangles.
    //InternalNodes do not.
    public List<Rectangle> Rectangles { get; set; }

    /// <summary>
    /// [TODO:description]
    /// </summary>
    public int xMin { get; set; }

    /// <summary>
    /// [TODO:description]
    /// </summary>
    public int yMin { get; set; }

    /// <summary>
    /// [TODO:description]
    /// </summary>
    public int xMax { get; set; }

    /// <summary>
    /// [TODO:description]
    /// </summary>
    public int yMax { get; set; }

    /// <summary>
    /// [TODO:description]
    /// </summary>
    /// <param name="xMin">[TODO:description]</param>
    /// <param name="yMin">[TODO:description]</param>
    /// <param name="xMax">[TODO:description]</param>
    /// <param name="yMax">[TODO:description]</param>
    public Node(int xMin, int yMin, int xMax, int yMax)
    {
        Rectangles = new List<Rectangle>();
        this.xMin = xMin;
        this.yMin = yMin;
        this.xMax = xMax;
        this.yMax = yMax;
    }

    /// <summary>
    /// [TODO:description]
    /// </summary>
    /// <param name="rect">[TODO:description]</param>
    public abstract void Insert(Rectangle rect);

    /// <summary>
    /// [TODO:description]
    /// </summary>
    /// <param name="x">[TODO:description]</param>
    /// <param name="y">[TODO:description]</param>
    public abstract void Delete(int x, int y);

    /// <summary>
    /// [TODO:description]
    /// </summary>
    /// <param name="x">[TODO:description]</param>
    /// <param name="y">[TODO:description]</param>
    /// <returns>[TODO:description]</returns>
    public abstract Rectangle Find(int x, int y);

    /// <summary>
    /// [TODO:description]
    /// </summary>
    /// <param name="x">[TODO:description]</param>
    /// <param name="y">[TODO:description]</param>
    /// <param name="length">[TODO:description]</param>
    /// <param name="width">[TODO:description]</param>
    public abstract void Update(int x, int y, int length, int width);

    /// <summary>
    /// [TODO:description]
    /// </summary>
    /// <param name="level">[TODO:description]</param>
    public abstract void Dump(int level);
}
