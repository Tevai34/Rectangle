namespace Quadtree;

/// <summary>
/// [TODO:description]
/// </summary>
public class Rectangle
{
    /// <summary>
    /// [TODO:description]
    /// </summary>
    public int x { get; set; }

    /// <summary>
    /// [TODO:description]
    /// </summary>
    public int y { get; set; }

    /// <summary>
    /// [TODO:description]
    /// </summary>
    public int length { get; set; }

    /// <summary>
    /// [TODO:description]
    /// </summary>
    public int width { get; set; }

    /// <summary>
    /// [TODO:description]
    /// </summary>
    /// <param name="x">[TODO:description]</param>
    /// <param name="y">[TODO:description]</param>
    /// <param name="length">[TODO:description]</param>
    /// <param name="width">[TODO:description]</param>
    public Rectangle(int x, int y, int length, int width)
    {
        // variables should begin with a lowercase letter.
        // You can access variable of the class with the same 
        // name as parameters using: this.<variable name>
        this.x = x;
        this.y = y;
        this.length = length;
        this.width = width;
    }
}
