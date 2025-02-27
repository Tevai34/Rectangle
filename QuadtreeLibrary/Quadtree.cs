namespace Quadtree;

/// Represents a Quadtree data structure used for spatial partitioning.
/// A quadtree is a tree data structure in which each internal node has exactly four children.
/// It is commonly used to part a two-dimensional space by recursively subdividing it into four quadrants.
/// This class serves as the main entry point for managing and interacting with the quadtree.
public class Quadtree
{
    /// The root node of the quadtree, which can be either an InternalNode or LeafNode.
    private Node root;

    /// The maximum number of rectangles a node can hold before splitting.
    private int threshold;

    /// Initializes a new instance of the class.
    /// The minimum x-coordinate of the quadtree.
    /// The minimum y-coordinate of the quadtree.
    /// The maximum x-coordinate of the quadtree.
    /// The maximum y-coordinate of the quadtree.
    /// The threshold for splitting nodes.
    public Quadtree(int xMin, int yMin, int xMax, int yMax, int threshold)
    {
        this.threshold = threshold;
        root = new InternalNode(xMin, yMin, xMax, yMax, threshold);
    }

    /// Inserts a rectangle into the quadtree.
    /// The rectangle to insert.
    public void Insert(Rectangle rect)
    {
        root.Insert(rect);
    }

    /// Deletes a rectangle from the quadtree based on its coordinates.
    /// The x-coordinate of the rectangle.
    /// The y-coordinate of the rectangle.
    public void Delete(int x, int y)
    {
        root.Delete(x, y);
    }

    /// Finds a rectangle in the quadtree based on its coordinates.
    /// The x-coordinate of the rectangle.
    /// The y-coordinate of the rectangle.
    
    public Rectangle Find(int x, int y)
    {
        /// The rectangle if found, otherwise null.
        return root.Find(x, y);
    }

    /// Updates the size of a rectangle in the quadtree.
    /// The x-coordinate of the rectangle.
    /// The y-coordinate of the rectangle.
    /// The new length of the rectangle.
    /// The new width of the rectangle.
    public void Update(int x, int y, int length, int width)
    {
        root.Update(x, y, length, width);
    }

    /// Dumps the structure of the quadtree for debugging purposes.
    public void Dump()
    {
        root.Dump(0);
    }
}



