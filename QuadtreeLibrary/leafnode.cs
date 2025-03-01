namespace Quadtree
{
    /// <summary>
    /// Represents a leaf node in the quadtree. This node holds rectangles and handles insertion, 
    /// deletion, and updates until it reaches the threshold, at which point it should split into sub-nodes.
    /// </summary>
    public class LeafNode : Node
    {
        /// <summary>
        /// The threshold for the number of rectangles before splitting.
        /// </summary>
        private int threshold;

        /// <summary>
        /// Initializes a new instance of the <see cref="LeafNode"/> class with a given space and threshold.
        /// </summary>
        /// <param name="threshold">The maximum number of rectangles the node can hold before splitting.</param>
        /// <param name="space">The spatial boundaries of this node.</param>
        public LeafNode(int threshold, Rectangle space) 
            : base(space.x, space.y, space.x + space.length, space.y + space.width)
        {
            this.threshold = threshold;
            this.Rectangles = new List<Rectangle>();
        }

        /// <summary>
        /// Inserts a rectangle into the node. If the node exceeds the threshold, it should split into sub-nodes.
        /// </summary>
        /// <param name="rect">The rectangle to insert into the node.</param>
        public override void Insert(Rectangle rect)
        {
            if (Rectangles.Count >= threshold)
            {
              throw new InvalidOperationException("Node exceeds threshold, splitting required.");
            }
            Rectangles.Add(rect);
        }

        /// <summary>
        /// Deletes a rectangle based on its coordinates from the node.
        /// </summary>
        /// <param name="x">The x-coordinate of the rectangle to delete.</param>
        /// <param name="y">The y-coordinate of the rectangle to delete.</param>
        public override void Delete(int x, int y)
        {
            var rect = Rectangles.FirstOrDefault(r => r.x == x && r.y == y);
            if (rect != null)
            {
                Rectangles.Remove(rect);
                Console.WriteLine($"Rectangle at ({x}, {y}) deleted.");
            }
            else
            {
                Console.WriteLine($"No rectangle found at ({x}, {y}) to delete.");
            }
        }

        /// <summary>
        /// Deletes a specific rectangle from the node.
        /// </summary>
        /// <param name="rect">The rectangle to delete.</param>
        public void Delete(Rectangle rect)
        {
            Delete(rect.x, rect.y);
        }

        /// <summary>
        /// Dumps the list of rectangles in the current node.
        /// </summary>
        /// <param name="level">The current depth level of the node, used for indentation in output.</param>
        public override void Dump(int level)
        {
            Console.WriteLine(new string('\t', level) + $"Leaf Node at [{xMin},{yMin}] to [{xMax},{yMax}]");
            foreach (var rect in Rectangles)
            {
                Console.WriteLine(new string('\t', level) + $"Rectangle at {rect.x}, {rect.y}: {rect.length}x{rect.width}");
            }
        }

        /// <summary>
        /// Updates the dimensions of a rectangle in the node.
        /// </summary>
        /// <param name="x">The x-coordinate of the rectangle to update.</param>
        /// <param name="y">The y-coordinate of the rectangle to update.</param>
        /// <param name="length">The new length of the rectangle.</param>
        /// <param name="width">The new width of the rectangle.</param>
        public override void Update(int x, int y, int length, int width)
        {
            var rect = Rectangles.FirstOrDefault(r => r.x == x && r.y == y);
            if (rect != null)
            {
                rect.length = length;
                rect.width = width;
                Console.WriteLine($"Updated rectangle at ({x}, {y}) to {length}x{width}.");
            }
            else
            {
                Console.WriteLine($"No rectangle found at ({x}, {y}) to update.");
            }
        }

        /// <summary>
        /// Finds a rectangle by its coordinates in the current node.
        /// </summary>
        /// <param name="x">The x-coordinate of the rectangle to find.</param>
        /// <param name="y">The y-coordinate of the rectangle to find.</param>
        /// <returns>The found rectangle, or <c>null</c> if no rectangle exists at the given coordinates.</returns>
        public override Rectangle? Find(int x, int y)        
        {
            foreach (var rect in Rectangles)
            {
                if (rect.x == x && rect.y == y)
            return rect;
            }
            return null;
        }
        
    }
}
