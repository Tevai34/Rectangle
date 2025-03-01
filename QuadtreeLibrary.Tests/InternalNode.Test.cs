using System;
using Xunit;
using System.Collections.Generic;

namespace Quadtree.Tests
{
    public class InternalNodeTests
    {
        [Fact]
        public void Insert_Rectangle_ShouldBeStoredInLeafOrSplit()
        {
            // Arrange
            InternalNode root = new InternalNode(0, 0, 100, 100, 2);
            Rectangle rect1 = new Rectangle(10, 10, 5, 5);
            Rectangle rect2 = new Rectangle(20, 20, 5, 5);
            Rectangle rect3 = new Rectangle(30, 30, 5, 5); // Should trigger a split

            // Act
            root.Insert(rect1);
            root.Insert(rect2);
            root.Insert(rect3);

            // Assert
            Assert.NotNull(root.Children);
            Assert.Equal(4, root.Children.Count);
        }

        [Fact]
        public void Find_ExistingRectangle_ShouldReturnRectangle()
        {
            // Arrange
            InternalNode root = new InternalNode(0, 0, 100, 100, 2);
            Rectangle rect = new Rectangle(25, 25, 5, 5);
            root.Insert(rect);

            // Act
            Rectangle? found = root.Find(25, 25);

            // Assert
            Assert.NotNull(found);
            Assert.Equal(rect.x, found.x);
            Assert.Equal(rect.y, found.y);
        }

        [Fact]
        public void Find_NonExistentRectangle_ShouldReturnNull()
        {
            // Arrange
            InternalNode root = new InternalNode(0, 0, 100, 100, 2);

            // Act
            Rectangle? found = root.Find(50, 50);

            // Assert
            Assert.Null(found);
        }

        [Fact]
        public void Delete_ExistingRectangle_ShouldRemoveIt()
        {
            // Arrange
            InternalNode root = new InternalNode(0, 0, 100, 100, 2);
            Rectangle rect = new Rectangle(25, 25, 5, 5);
            root.Insert(rect);

            // Act
            root.Delete(25, 25);
            Rectangle? found = root.Find(25, 25);

            // Assert
            Assert.Null(found);
        }

        [Fact]
        public void Update_Rectangle_ShouldChangeItsSize()
        {
            // Arrange
            InternalNode root = new InternalNode(0, 0, 100, 100, 2);
            Rectangle rect = new Rectangle(40, 40, 5, 5);
            root.Insert(rect);

            // Act
            root.Update(40, 40, 10, 10);
            Rectangle? updated = root.Find(40, 40);

            // Assert
            Assert.NotNull(updated);
            Assert.Equal(10, updated.length);
            Assert.Equal(10, updated.width);
        }

        [Fact]
        public void Dump_ShouldOutputStructure()
        {
            // Arrange
            InternalNode root = new InternalNode(0, 0, 100, 100, 2);
            root.Insert(new Rectangle(10, 10, 5, 5));
            root.Insert(new Rectangle(20, 20, 5, 5));
            root.Insert(new Rectangle(30, 30, 5, 5)); // Causes a split

            // Act
            var writer = new System.IO.StringWriter();
            Console.SetOut(writer);
            root.Dump(0);
            string output = writer.ToString();

            // Assert
            Assert.Contains("Internal Node", output);
            Assert.Contains("LeafNode", output);
        }
    }
}


