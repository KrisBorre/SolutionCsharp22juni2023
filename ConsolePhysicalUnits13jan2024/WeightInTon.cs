namespace ConsolePhysicalUnits13jan2024
{
    internal class WeightInTon : IWeight
    {
        private double m_WeightInTon;
        private double m_PrecisionInTon;

        public WeightInTon(double weightInTon, double accuracyInTon)
        {
            m_WeightInTon = weightInTon;
            m_PrecisionInTon = accuracyInTon;
        }

        public int GetInKilogram()
        {
            return WeightCalculation.ConvertTonIntoKilogram(m_WeightInTon);
        }

        public int GetPrecisionInKilogram()
        {
            return Convert.ToInt32(m_PrecisionInTon * 1000);
        }

        public double GetInTon()
        {
            return m_WeightInTon;
        }

        public double GetPrecisionInTon()
        {
            return m_PrecisionInTon;
        }
    }
}
