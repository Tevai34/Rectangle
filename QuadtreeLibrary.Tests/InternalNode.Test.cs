using System;
using Xunit;
using System.Collections.Generic;

namespace Quadtree.Tests
{
    public class InternalNodeTests
    {
        /// Tests inserting rectangles into the quadtree.
        /// Ensures that when the threshold is exceeded, the node splits into child nodes.
        [Fact]
        public void Insert_Rectangle_ShouldBeStoredInLeafOrSplit()
        {
            /// Arrange Create a quadtree internal node with a threshold of 2
            InternalNode root = new InternalNode(0, 0, 100, 100, 2);
            Rectangle rect1 = new Rectangle(10, 10, 5, 5);
            Rectangle rect2 = new Rectangle(20, 20, 5, 5);
            /// Third insert should trigger a split
            Rectangle rect3 = new Rectangle(30, 30, 5, 5); 

            // Act Insert rectangles into the quadtree
            root.Insert(rect1);
            root.Insert(rect2);
            root.Insert(rect3);

            /// Assert Ensure the node has split into four children
            Assert.NotNull(root.Children);
            Assert.Equal(4, root.Children.Count);
        }

        /// Tests finding an existing rectangle in the quadtree.
        [Fact]
        public void Find_ExistingRectangle_ShouldReturnRectangle()
        {
            /// Arrange Create a quadtree and insert a rectangle
            InternalNode root = new InternalNode(0, 0, 100, 100, 2);
            Rectangle rect = new Rectangle(25, 25, 5, 5);
            root.Insert(rect);

            /// Act Try to find the rectangle
            Rectangle found = root.Find(25, 25);

            /// Assert Ensure the correct rectangle is found
            Assert.NotNull(found);
            Assert.Equal(25, found.x);
            Assert.Equal(25, found.y);
        }

        /// Tests that searching for a non-existent rectangle returns null.
        [Fact]
        public void Find_NonExistentRectangle_ShouldReturnNull()
        {
            /// Arrange Create a quadtree with no rectangles inserted
            InternalNode root = new InternalNode(0, 0, 100, 100, 2);

            /// Act Try to find a non-existent rectangle
            Rectangle found = root.Find(50, 50);

            /// Assert Ensure the result is null
            Assert.Null(found);
        }

        /// Tests deleting an existing rectangle from the quadtree.
        [Fact]
        public void Delete_ExistingRectangle_ShouldRemoveIt()
        {
            /// Arrange Create a quadtree and insert a rectangle
            InternalNode root = new InternalNode(0, 0, 100, 100, 2);
            Rectangle rect = new Rectangle(25, 25, 5, 5);
            root.Insert(rect);

            /// Act Delete the rectangle and try to find it again
            root.Delete(25, 25);
            Rectangle found = root.Find(25, 25);

            /// Assert The rectangle should no longer exist
            Assert.Null(found);
        }

        /// Tests updating a rectangle's dimensions in the quadtree.
        [Fact]
        public void Update_Rectangle_ShouldChangeItsSize()
        {
            /// Arrange Create a quadtree and insert a rectangle
            InternalNode root = new InternalNode(0, 0, 100, 100, 2);
            Rectangle rect = new Rectangle(40, 40, 5, 5);
            root.Insert(rect);

            /// Act Update the rectangle's size
            root.Update(40, 40, 10, 10);
            Rectangle updated = root.Find(40, 40);

            /// Assert Ensure the dimensions have been updated
            Assert.NotNull(updated);
            Assert.Equal(10, updated.length);
            Assert.Equal(10, updated.width);
        }

        /// Tests the Dump method to ensure it prints the correct quadtree structure.
        [Fact]
        public void Dump_ShouldOutputStructure()
        {
            /// Arrange Create a quadtree and insert rectangles to cause a split
            InternalNode root = new InternalNode(0, 0, 100, 100, 2);
            root.Insert(new Rectangle(10, 10, 5, 5));
            root.Insert(new Rectangle(20, 20, 5, 5));
            root.Insert(new Rectangle(30, 30, 5, 5)); // Causes a split

            /// Act Capture console output of Dump method
            var writer = new System.IO.StringWriter();
            Console.SetOut(writer);
            root.Dump(0);
            string output = writer.ToString();

            /// Assert Ensure output contains expected structure indicators
            Assert.Contains("Internal Node", output);
            Assert.Contains("LeafNode", output);
        }
    }
}


