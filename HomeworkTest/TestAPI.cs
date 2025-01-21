using Homework;

namespace HomeworkTest;

public class TestAPI
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var jsonString = Message.getPublicApiDataAsync("Senica", "2025-01-21");
        Assert.IsNotNull(jsonString);
    }
}
