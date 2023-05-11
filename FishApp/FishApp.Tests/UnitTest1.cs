namespace FishApp.Tests
{
    public class Tests
    {
        [Test]
        public void FishTest()
        {
            var fish = new FishInMemory("Jesiotr", "15kg", "15:02");
            fish.AddGrade(5);
            fish.AddGrade(1);
            fish.AddGrade(2);
            fish.AddGrade(3);
            fish.AddGrade(9);

            var result = fish.GetStatistics();

            Assert.AreEqual(4, result.Average, 1);
            Assert.AreEqual(9, result.Max, 1);
            Assert.AreEqual(1, result.Min, 1);
            Assert.AreEqual(20, result.Sum, 1);
            Assert.AreEqual(5, result.Count, 1);

        }
    }
}