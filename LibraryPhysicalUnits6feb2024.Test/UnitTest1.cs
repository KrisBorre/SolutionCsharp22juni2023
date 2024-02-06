namespace LibraryPhysicalUnits6feb2024.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            WeightInKilogram weightJohn = new WeightInKilogram(80, 1);
            Assert.Equal(0.080, weightJohn.GetInTon());
        }

        [Fact]
        public void Test2()
        {
            IWeight weight = new WeightInKilogram(10, 0);
            Assert.Equal(10, weight.GetInKilogram());
        }

        [Fact]
        public void Test3()
        {
            WeightInKilogram weightInKilogram = new WeightInKilogram(80, 1);

            IWeight weight1 = new WeightInKilogram(60, 3);

            IWeight weight2 = new WeightInTon(0.072, 0.01);

            WeightInKilogram totalWeight = WeightCalculation.Add(weight1, weightInKilogram);

            Assert.Equal(expected: 140, actual: totalWeight.GetInKilogram());

            totalWeight = WeightCalculation.Add(weight1, weight2);

            Assert.Equal(expected: 132, actual: totalWeight.GetInKilogram());
        }

        [Fact]
        public void Test4()
        {
            WeightInKilogram weightInKilogram = new WeightInKilogram(80, 1);

            IWeight weight1 = new WeightInKilogram(60, 3);

            IWeight weight2 = new WeightInTon(0.072, 0.01);

            WeightInKilogram totalWeight = WeightCalculation.Add(weightInKilogram, weight1);

            Assert.Equal(expected: 140, actual: totalWeight.GetInKilogram());

            Assert.Equal(expected: 0.14, actual: totalWeight.GetInTon());

            IWeight weight3 = WeightCalculation.Add(weight2, weight1);

            Assert.Equal(expected: 132, actual: weight3.GetInKilogram());

            Assert.Equal(expected: 0.132, actual: weight3.GetInTon());
        }
    }
}