namespace Quadtree.Tests;

public class QuadtreeTests
{
    [Fact]
    public void TestInsertRectangles()
    {
        var quadtree = new Quadtree(0, 0, 100, 100, 4);
        var rect = new Rectangle(10, 10, 5, 5);
        quadtree.Insert(rect);

        var foundRect = quadtree.Find(10, 10);
        Assert.Equal(rect, foundRect);
    }

    [Fact]
    public void TestDeleteRectangles()
    {
        var quadtree = new Quadtree(0, 0, 100, 100,4);
        var rect = new Rectangle(10, 10, 5, 5);
        quadtree.Insert(rect);

        quadtree.Delete(10, 10);
        var foundRect = quadtree.Find(10, 10);
        Assert.Null(foundRect);
    }
}

