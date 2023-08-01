namespace SOLIDSorting1Aug2023
{
    internal class QuickSorter : Sorter, ISorter
    {
        public QuickSorter(ISwapper swapper) : base(swapper)
        { }

        public override void Sort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }

        private void QuickSort(int[] array, int Left, int Right)
        {
            int L = Left;
            int R = Right;
            int pivotValue = array[(Left + Right) / 2];

            do
            {
                while (array[L] < pivotValue)
                {
                    L++;
                }
                while (pivotValue < array[R])
                {
                    R--;
                }

                if (L <= R)
                {
                    this.Swapper.Swap(L, R, array);
                    L++;
                    R--;
                }
            } while (L < R);

            if (Left < R)
            {
                QuickSort(array, Left, R);
            }
            if (L < Right)
            {
                QuickSort(array, L, Right);
            }
        }

        public override string ToString()
        {
            return "QuickSort";
        }
    }
}
