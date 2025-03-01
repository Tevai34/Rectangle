namespace Quadtree
{
    /// <summary>
    /// Represents an internal node in the quadtree. This node contains child nodes and is responsible 
    /// for splitting when the number of rectangles exceeds the threshold.
    /// </summary>
    public class InternalNode : Node
    {
        /// <summary>
        /// Gets or sets the list of child nodes.
        /// </summary>
        public List<Node> Children { get; set; }

        private int threshold;

        /// <summary>
        /// Initializes a new instance of the <see cref="InternalNode"/> class with given space and threshold.
        /// </summary>
        /// <param name="xMin">The minimum x-coordinate of the node's space.</param>
        /// <param name="yMin">The minimum y-coordinate of the node's space.</param>
        /// <param name="xMax">The maximum x-coordinate of the node's space.</param>
        /// <param name="yMax">The maximum y-coordinate of the node's space.</param>
        /// <param name="threshold">The threshold for the number of rectangles before splitting.</param>
        public InternalNode(int xMin, int yMin, int xMax, int yMax, int threshold) 
            : base(xMin, yMin, xMax, yMax)
        {
            this.threshold = threshold;
            this.Children = new List<Node>();
        }

        /// <summary>
        /// Inserts a rectangle into the node. If the node exceeds the threshold, it splits into child nodes.
        /// </summary>
        /// <param name="rect">The rectangle to insert into the node.</param>
        public override void Insert(Rectangle rect)
        {
            if (Rectangles.Count < threshold)
            {
                // If the node has fewer than the threshold, insert the rectangle directly
                Rectangles.Add(rect);
            }
            else
            {
                // Split the node into 4 child nodes if it exceeds the threshold
                SplitNode();

                // Now insert the rectangle into the appropriate child node
                InsertIntoChildNode(rect);
            }
        }

        /// <summary>
        /// Splits the node into 4 quadrants (child nodes) when the threshold is exceeded.
        /// </summary>
        private void SplitNode()
        {
            // Define the midpoint of the current space
            int midX = (xMin + xMax) / 2;
            int midY = (yMin + yMax) / 2;

            // Create four new child LeafNodes representing the quadrants
            Children = new List<Node>
            {
                new LeafNode(threshold, new Rectangle(xMin, midY, midX, yMax)), // Top-left
                new LeafNode(threshold, new Rectangle(midX, midY, xMax, yMax)), // Top-right
                new LeafNode(threshold, new Rectangle(xMin, yMin, midX, midY)), // Bottom-left
                new LeafNode(threshold, new Rectangle(midX, yMin, xMax, midY))  // Bottom-right
            };

            // Distribute the existing rectangles to the correct child nodes
            foreach (var rectangle in Rectangles)
            {
                InsertIntoChildNode(rectangle);
            }

            // Clear the current list of rectangles as they have been moved to child nodes
            Rectangles.Clear();
        }

        /// <summary>
        /// Inserts a rectangle into the appropriate child node based on its position.
        /// </summary>
        /// <param name="rect">The rectangle to insert into the child node.</param>
        private void InsertIntoChildNode(Rectangle rect)
        {
            Node? targetChild = null;

            // Determine which quadrant the rectangle belongs to and assign it to the correct child node
            if (rect.x < (xMin + xMax) / 2 && rect.y >= (yMin + yMax) / 2)
            {
                targetChild = Children[0];  // Top-left
            }
            else if (rect.x >= (xMin + xMax) / 2 && rect.y >= (yMin + yMax) / 2)
            {
                targetChild = Children[1];  // Top-right
            }
            else if (rect.x < (xMin + xMax) / 2 && rect.y < (yMin + yMax) / 2)
            {
                targetChild = Children[2];  // Bottom-left
            }
            else if (rect.x >= (xMin + xMax) / 2 && rect.y < (yMin + yMax) / 2)
            {
                targetChild = Children[3];  // Bottom-right
            }

            // Insert the rectangle into the target child node (either LeafNode or InternalNode)
            if (targetChild is LeafNode leafNode)
            {
                leafNode.Insert(rect);
            }
            else if (targetChild is InternalNode internalNode)
            {
                targetChild?.Insert(rect);
            }
        }

        /// <summary>
        /// Deletes a rectangle based on its coordinates from the node.
        /// </summary>
        /// <param name="x">The x-coordinate of the rectangle to delete.</param>
        /// <param name="y">The y-coordinate of the rectangle to delete.</param>
        public override void Delete(int x, int y)
        {
            foreach (var child in Children)
            {
                child.Delete(x, y);
            }
        }

        /// <summary>
        /// Finds a rectangle based on its coordinates in the node's children.
        /// </summary>
        /// <param name="x">The x-coordinate of the rectangle to find.</param>
        /// <param name="y">The y-coordinate of the rectangle to find.</param>
        /// <returns>The rectangle found, or <c>null</c> if not found.</returns>
        public override Rectangle ? Find(int x, int y)
        {
            foreach (var child in Children)
            {
                var rect = child.Find(x, y);
                if (rect != null)
                    return rect;
            }
            return null;
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
            foreach (var child in Children)
            {
                child.Update(x, y, length, width);
            }
        }

        /// <summary>
        /// Dumps the structure of the internal node and its children.
        /// </summary>
        /// <param name="level">The depth level for indentation in the dump output.</param>
        public override void Dump(int level)
        {
            Console.WriteLine(new string('\t', level) + $"Internal Node at [{xMin},{yMin}] to [{xMax},{yMax}]");
            foreach (var child in Children)
            {
                child.Dump(level + 1);
            }
        }
    }
}
