namespace LibraryPhysicalUnits6feb2024
{
    public static class WeightCalculation
    {
        public static int ConvertTonIntoKilogram(double weight)
        {
            return Convert.ToInt32(weight * 1000);
        }

        public static double ConvertKilogramIntoTon(int weight)
        {
            return weight / 1000.0;
        }

        /// <summary>
        /// Precondition: weight1 and weight2 are independently measured
        /// </summary>
        /// <param name="weight1"></param>
        /// <param name="weight2"></param>
        /// <returns></returns>
        public static WeightInKilogram Add(IWeight weight1, IWeight weight2)
        {
            double accuracy = Math.Sqrt(Math.Pow(weight1.GetPrecisionInKilogram(), 2) + Math.Pow(weight2.GetPrecisionInKilogram(), 2));
            return new WeightInKilogram(weight1.GetInKilogram() + weight2.GetInKilogram(), Convert.ToInt32(Math.Ceiling(accuracy)));
        }
    }
}
