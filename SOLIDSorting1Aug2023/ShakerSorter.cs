namespace SOLIDSorting1Aug2023
{
    internal class ShakerSorter : Sorter, ISorter
    {
        public ShakerSorter(ISwapper swapper) : base(swapper)
        { }

        public override void Sort(int[] array)
        {
            bool swapped = true;
            while (swapped)
            {
                swapped = false;
                for (int i = 0; i < array.Length - 1; ++i)
                {
                    if (array[i] > array[i + 1])
                    {
                        swapped = true;
                        this.Swapper.Swap(i, i + 1, array);
                    }
                }

                if (!swapped) break;

                for (int i = array.Length - 2; i >= 0; --i)
                {
                    if (array[i] > array[i + 1])
                    {
                        swapped = true;
                        this.Swapper.Swap(i, i + 1, array);
                    }
                }
            }
        }

        public override string ToString()
        {
            return "ShakerSort";
        }
    }
}
