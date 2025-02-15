public class QuadtreeTests
{
    [Fact]
    public void TestInsertRectangle()
    {
        var quadtree = new Quadtree();
        var rect = new Rectangle(10, 10, 5, 5);
        quadtree.Insert(rect);

        var foundRect = quadtree.Find(10, 10);
        Assert.Equal(rect, foundRect);
    }

    [Fact]
    public void TestDeleteRectangle()
    {
        var quadtree = new Quadtree();
        var rect = new Rectangle(10, 10, 5, 5);
        quadtree.Insert(rect);

        quadtree.Delete(10, 10);
        var foundRect = quadtree.Find(10, 10);
        Assert.Null(foundRect);
    }
}
