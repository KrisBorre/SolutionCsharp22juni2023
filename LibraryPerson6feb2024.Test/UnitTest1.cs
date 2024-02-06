using LibraryPhysicalUnits6feb2024;

namespace LibraryPerson6feb2024.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            WeightInKilogram weightJohn = new WeightInKilogram(80, 1);

            Person mike = new Person();
            mike.Name = "Mike";
            mike.Weight = new WeightInKilogram(60, 3);

            Person tom = new Person();
            tom.Name = "Tom";
            tom.Weight = weightJohn;

            Person billy = new Person();
            billy.Name = "Billy";
            billy.Weight = new WeightInTon(0.072, 0.01);

            WeightInKilogram totalWeight = WeightCalculation.Add(tom.Weight, mike.Weight);

            Assert.Equal(expected: 140, actual: totalWeight.GetInKilogram());

            totalWeight = WeightCalculation.Add(tom.Weight, billy.Weight);
            
            Assert.Equal(expected: 152, actual: totalWeight.GetInKilogram());           
        }
    }
}