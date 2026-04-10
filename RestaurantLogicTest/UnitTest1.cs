using RestaurantLogic;

namespace RestaurantLogicTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            int result = new Class1().M();
            Assert.AreEqual(5, result);
            Assert.That(result, Is.EqualTo(5));
        }
    }
}