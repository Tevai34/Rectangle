namespace Quadtree.Tests;

public class QuadtreeTests
{
    [Fact]
    public void Insert_Rectangle_ShouldBeFound()
    {
        // Arrange
        var quadtree = new Quadtree(0, 0, 100, 100, 4);
        var rect = new Rectangle(10, 10, 5, 5);

        // Act
        quadtree.Insert(rect);
        var foundRect = quadtree.Find(10, 10);

        // Assert
        Assert.NotNull(foundRect);
        Assert.Equal(rect, foundRect);
    }

    [Fact]
    public void Delete_Rectangle_ShouldNotBeFound()
    {
        // Arrange
        var quadtree = new Quadtree(0, 0, 100, 100, 4);
        var rect = new Rectangle(10, 10, 5, 5);
        quadtree.Insert(rect);

        // Ensure it exists before deletion
        Assert.NotNull(quadtree.Find(10, 10));

        // Act
        quadtree.Delete(10, 10);
        var foundAfterDelete = quadtree.Find(10, 10);

        // Assert
        Assert.Null(foundAfterDelete);
    }
}


