namespace SOLIDSorting1Aug2023
{
    internal interface ISwapper
    {
        int Swapped { get; }

        void Swap(int index1, int index2, int[] array);
    }
}
