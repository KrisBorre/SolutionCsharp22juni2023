namespace SOLIDSorting1Aug2023
{
    internal abstract class Sorter : ISorter
    {
        public ISwapper Swapper { get; set; }

        public Sorter(ISwapper swapper)
        {
            Swapper = swapper;
        }

        public abstract void Sort(int[] array);

    }
}
