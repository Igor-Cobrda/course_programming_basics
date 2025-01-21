namespace HomeworkTest
{
    public class TestVstupov
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            string city = Homework.Message.zadavanieMesta("Praha");
            Assert.AreEqual("Praha", city);
        }

        [Test]
        public void Test2()
        {
            string city = Homework.Message.zadavanieMesta("");
            Assert.AreNotEqual("", city);
        }

        [Test]
        public void Test3()
        {
            string city = Homework.Message.zadavanieMesta("22");
            Assert.AreEqual("Senica", city);
        }

        [Test]
        public void Test4()
        {
            string date = Homework.Message.zadavanieDatumu("", "2025-01-21");
            Assert.AreNotEqual("", date);
        }

        [Test]
        public void Test5()
        {
            string date = Homework.Message.zadavanieDatumu("2025-01-21", "2025-01-22");
            Assert.AreEqual("2025-01-21", date);
        }
    }
}