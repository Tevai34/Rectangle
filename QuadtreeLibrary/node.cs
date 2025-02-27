namespace Quadtree;

/// Represents a node in the quadtree. A node can be either an internal node (with children)
/// or a leaf node (storing rectangles).
public abstract class Node
{
    /// The minimum x-coordinate of the node's boundary.
    public int xMin { get; set; }

    /// The minimum y-coordinate of the node's boundary.

    public int yMin { get; set; }

    /// The maximum x-coordinate of the node's boundary.
    public int xMax { get; set; }

    /// The maximum y-coordinate of the node's boundary.

    public int yMax { get; set; }
    /// A list of rectangles contained within this node. This is primarily used by leaf nodes.
    /// Internal nodes typically delegate storage to their child nodes.

    public List<Rectangle> Rectangles { get; set; }

    /// Initializes a new instance of the class.
    /// The minimum x-coordinate of the node's boundary.
    /// The minimum y-coordinate of the node's boundary.
    /// The maximum x-coordinate of the node's boundary.
    /// The maximum y-coordinate of the node's boundary.
    public Node(int xMin, int yMin, int xMax, int yMax)
    {
        Rectangles = new List<Rectangle>();
        this.xMin = xMin;
        this.yMin = yMin;
        this.xMax = xMax;
        this.yMax = yMax;
    }

    /// Inserts a rectangle into the node.
    /// If the node is a leaf, it stores the rectangle directly.
    /// If the node is an internal node, it delegates the insertion to the appropriate child.
    /// The rectangle to insert.
    public abstract void Insert(Rectangle rect);

    /// Deletes a rectangle from the node based on the given coordinates.
    /// The x-coordinate of the rectangle to delete.
    /// The y-coordinate of the rectangle to delete.
    public abstract void Delete(int x, int y);

    /// Finds a rectangle in the quadtree based on the given coordinates.
    /// The x-coordinate of the rectangle to find.
    /// The y-coordinate of the rectangle to find.
    public abstract Rectangle Find(int x, int y);

    /// Updates a rectangle's dimensions in the node.
    /// The x-coordinate of the rectangle to update.
    /// The y-coordinate of the rectangle to update.
    /// The new length of the rectangle.
    /// The new width of the rectangle.
    public abstract void Update(int x, int y, int length, int width);

    /// The depth level of the current node used for indentation.
    public abstract void Dump(int level);
