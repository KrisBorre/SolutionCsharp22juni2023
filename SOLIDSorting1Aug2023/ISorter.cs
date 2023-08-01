namespace SOLIDSorting1Aug2023
{
    interface ISorter
    {
        ISwapper Swapper { get; set; }

        void Sort(int[] array);
    }
}
