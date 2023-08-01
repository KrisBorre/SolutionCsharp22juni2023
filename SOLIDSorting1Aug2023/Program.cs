using SOLIDSorting1Aug2023;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welkom bij SOLID SortingApplication");

        List<ISorter> sorters = new List<ISorter>();
        sorters.Add(new BubbleSorter(new Swapper()));
        sorters.Add(new ShakerSorter(new Swapper()));
        sorters.Add(new QuickSorter(new Swapper()));
        foreach (ISorter sorter in sorters)
        {
            int[] array = { 88, 12, 55, 105, 48, 84, 66, 35, 57, 89, 74, 106, 200, 541, 1, 9, 7, 55, 405, 13 };
            sorter.Sort(array);
            Console.WriteLine($"Sorting done using {sorter}, needed {sorter.Swapper.Swapped} swaps to sort the array");
        }

        // Sorting done using BubbleSort, needed 94 swaps to sort the array
        // Sorting done using ShakerSort, needed 94 swaps to sort the array
        // Sorting done using QuickSort, needed 27 swaps to sort the array

        Console.ReadKey();
    }
}