namespace LibraryPhysicalUnits6feb2024
{
    public class WeightInKilogram : IWeight
    {
        private int m_WeightInKilogram;
        private int m_PrecisionInKilogram;

        public WeightInKilogram(int weightInKilogram, int precisionInKilogram)
        {
            m_WeightInKilogram = weightInKilogram;
            m_PrecisionInKilogram = precisionInKilogram;
        }

        public int GetInKilogram()
        {
            return m_WeightInKilogram;
        }

        public double GetInTon()
        {
            return m_WeightInKilogram / 1000.0;
        }

        public int GetPrecisionInKilogram()
        {
            return m_PrecisionInKilogram;
        }
    }
}
