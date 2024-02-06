using LibraryPerson6feb2024;
using LibraryPhysicalUnits6feb2024;
using System.Diagnostics;

namespace ConsolePhysicalUnits6feb2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // https://en.wikipedia.org/wiki/List_of_physical_quantities
            // https://en.wikipedia.org/wiki/International_System_of_Units
            Console.WriteLine("Hello, Physical Units!");

            WeightInKilogram weightJohn = new WeightInKilogram(80, 1);
            Debug.Assert(weightJohn.GetInTon() == 0.080, "wrong weight");
            Console.WriteLine("John's weight is " + weightJohn.GetInTon() + " Ton.");

            Person Mike = new Person();
            Mike.Name = "Mike";
            Mike.Weight = new WeightInKilogram(60, 3);

            Person Tom = new Person();
            Tom.Name = "Tom";
            Tom.Weight = weightJohn;

            Console.WriteLine("Mike's weight is " + Mike.Weight.GetInKilogram() + " kilo.");

            Console.WriteLine("Tom his weight is " + Tom.Weight.GetInKilogram() + " kilo.");

            Person Billy = new Person();
            Billy.Name = "Billy";
            Billy.Weight = new WeightInTon(0.072, 0.01);
            Console.WriteLine("Billy's weight is " + Billy.Weight.GetInKilogram() + " kilo.");
            Console.WriteLine("Billy's weight accuracy is " + Billy.Weight.GetPrecisionInKilogram() + " kilo.");

            WeightInKilogram totalWeight = WeightCalculation.Add(Tom.Weight, Mike.Weight);
            Console.WriteLine("The sum of the weight of Tom and Mike is " + totalWeight.GetInKilogram() + " plusminus " + totalWeight.GetPrecisionInKilogram() + " kilo");
            Debug.Assert(totalWeight.GetInKilogram() == 140);

            totalWeight = WeightCalculation.Add(Tom.Weight, Billy.Weight);
            Console.WriteLine("The sum of the weight of Tom and Billy is " + totalWeight.GetInKilogram() + " plusminus " + totalWeight.GetPrecisionInKilogram() + " kilo");
            Debug.Assert(totalWeight.GetInKilogram() == 152);

            IWeight weight = new WeightInKilogram(10, 0);
            Billy.Weight = weight;
            Tom.Weight = new WeightInKilogram(10, 0);

            if (Tom.Weight.Equals(Billy.Weight))
            {
                Console.WriteLine("equal");
            }
            else
            {
                Console.WriteLine("different");
            }
            // Implemented as a struct the weights are equal.
            // Implemented as a class the weights are different.

            Person Tony = new Person();
            Tony.Weight = new WeightInKilogram(91, 1);
            Console.WriteLine("Tony's weight is " + Billy.Weight.GetInKilogram() + " kilograms.");
        }
    }
}
