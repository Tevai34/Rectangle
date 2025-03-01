namespace Quadtree
{
    /// <summary>
    /// Represents a Quadtree data structure used for spatial partitioning.
    /// A quadtree is a tree data structure in which each internal node has exactly four children.
    /// It is commonly used to partition a two-dimensional space by recursively subdividing it into four quadrants.
    /// This class serves as the main entry point for managing and interacting with the quadtree.
    /// </summary>
    public class Quadtree
    {
        /// <summary>
        /// The root node of the quadtree, which can be either an <see cref="InternalNode"/> or <see cref="LeafNode"/>.
        /// </summary>
        private Node root;

        /// <summary>
        /// The maximum number of rectangles a node can hold before splitting.
        /// </summary>
        private int threshold;

        /// <summary>
        /// Initializes a new instance of the <see cref="Quadtree"/> class.
        /// </summary>
        /// <param name="xMin">The minimum x-coordinate of the quadtree.</param>
        /// <param name="yMin">The minimum y-coordinate of the quadtree.</param>
        /// <param name="xMax">The maximum x-coordinate of the quadtree.</param>
        /// <param name="yMax">The maximum y-coordinate of the quadtree.</param>
        /// <param name="threshold">The threshold for splitting nodes.</param>
        public Quadtree(int xMin, int yMin, int xMax, int yMax, int threshold)
        {
            this.threshold = threshold;
            root = new InternalNode(xMin, yMin, xMax, yMax, threshold);
        }

        /// <summary>
        /// Inserts a rectangle into the quadtree.
        /// </summary>
        /// <param name="rect">The rectangle to insert.</param>
        public void Insert(Rectangle rect)
        {
            root.Insert(rect);
        }

        /// <summary>
        /// Deletes a rectangle from the quadtree based on its coordinates.
        /// </summary>
        /// <param name="x">The x-coordinate of the rectangle.</param>
        /// <param name="y">The y-coordinate of the rectangle.</param>
        public void Delete(int x, int y)
        {
            root.Delete(x, y);
        }

        /// <summary>
        /// Finds a rectangle in the quadtree based on its coordinates.
        /// </summary>
        /// <param name="x">The x-coordinate of the rectangle.</param>
        /// <param name="y">The y-coordinate of the rectangle.</param>
        /// <returns>The found rectangle if it exists; otherwise, <c>null</c>.</returns>
        public Rectangle Find(int x, int y)
        {
            return root.Find(x, y);
        }

        /// <summary>
        /// Updates the size of a rectangle in the quadtree.
        /// </summary>
        /// <param name="x">The x-coordinate of the rectangle.</param>
        /// <param name="y">The y-coordinate of the rectangle.</param>
        /// <param name="length">The new length of the rectangle.</param>
        /// <param name="width">The new width of the rectangle.</param>
        public void Update(int x, int y, int length, int width)
        {
            root.Update(x, y, length, width);
        }

        /// <summary>
        /// Dumps the structure of the quadtree for debugging purposes.
        /// </summary>
        public void Dump()
        {
            root.Dump(0);
        }
    }
}



