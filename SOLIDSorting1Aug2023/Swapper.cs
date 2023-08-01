namespace SOLIDSorting1Aug2023
{
    internal class Swapper : ISwapper
    {
        public int Swapped { get; private set; } = 0;

        public void Swap(int index1, int index2, int[] array)
        {
            int temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
            Swapped++;
        }
    }
}
