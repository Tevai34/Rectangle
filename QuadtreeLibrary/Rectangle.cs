namespace Quadtree
{
    /// Represents a rectangle defined by its position and dimensions.
    public class Rectangle
    {
        /// Gets or sets the x-coordinate of the rectangle's top-left corner.
        public int x { get; set; }

        /// Gets or sets the y-coordinate of the rectangle's top-left corner.
        public int y { get; set; }

        /// Gets or sets the length (height) of the rectangle.
        public int length { get; set; }

        /// <summary>
        /// Gets or sets the width of the rectangle.
        /// </summary>
        public int width { get; set; }

        /// Initializes a new instance of the class with specified coordinates and dimensions.
        /// The x-coordinate of the rectangle's top-left corner.
        /// The y-coordinate of the rectangle's top-left corner.
        /// The length (height) of the rectangle.
        /// The width of the rectangle.
        public Rectangle(int x, int y, int length, int width)
        {
            this.x = x;
            this.y = y;
            this.length = length;
            this.width = width;
        }

        /// Gets the area of the rectangle (length * width).
        /// The area of the rectangle.
        public int GetArea()
        {
            return length * width;
        }

        /// Gets the perimeter of the rectangle (2 * (length + width)).
        /// The perimeter of the rectangle.
        public int GetPerimeter()
        {
            return 2 * (length + width);
        }

        /// Determines if a given point (px, py) is inside the rectangle.
        /// The x-coordinate of the point to check.
        /// The y-coordinate of the point to check.
        ///True if the point is inside the rectangle, otherwise false.
        public bool IsPointInside(int px, int py)
        {
            return px >= x && px <= x + width && py >= y && py <= y + length;
        }
    }
}
