using System;
using System.Diagnostics;
using System.Linq;

namespace Sorting
{
    class Program
    {
        private const int TotalRandomNumbers = 10;
        static void Main(string[] args)
        {
            #region Insertion Sort
            var insertionSortData = DataGeneration.GetData(TotalRandomNumbers);
            var insertionSortTime = Stopwatch.StartNew();

            Sorts.InsertionSort(insertionSortData);
            insertionSortTime.Stop();

            Sorts.Print(insertionSortData);
            Console.WriteLine($"{Environment.NewLine}Insertion Sort ===> {TimeSpan.FromTicks(insertionSortTime.ElapsedTicks).TotalMilliseconds }");
            #endregion

            #region Selection Sort
            var selectionSort = DataGeneration.GetData(TotalRandomNumbers);
            var selectionSortTime = Stopwatch.StartNew();
            Sorts.SelectionSort(selectionSort);
            selectionSortTime.Stop();

            Sorts.Print(selectionSort);
            Console.WriteLine($"{Environment.NewLine}Selection Sort ===> {TimeSpan.FromTicks(selectionSortTime.ElapsedTicks).TotalMilliseconds }");
            #endregion

            #region QuickSort
            var quickSortData = DataGeneration.GetData(TotalRandomNumbers);
            var quickSortTime = Stopwatch.StartNew();
            Sorts.QuickSort(quickSortData, 0, quickSortData.Count - 1);
            quickSortTime.Stop();

            Sorts.Print(quickSortData);
            Console.WriteLine($"{Environment.NewLine}Quick Sort ===> {TimeSpan.FromTicks(quickSortTime.ElapsedTicks).TotalMilliseconds }");
            #endregion

            #region Heap Sort
            var heapSortData = DataGeneration.GetData(TotalRandomNumbers);
            var heapSortTime = Stopwatch.StartNew();
            Sorts.HeapSort(heapSortData);
            heapSortTime.Stop();

            Sorts.Print(heapSortData);
            Console.WriteLine($"{Environment.NewLine}Heap Sort ===> {TimeSpan.FromTicks(heapSortTime.ElapsedTicks).TotalMilliseconds }");
            #endregion

            #region Merge Sort Temporal Array
            var mergeSortData = DataGeneration.GetData(TotalRandomNumbers);
            var mergeSortTime = Stopwatch.StartNew();
            Sorts.MergeSortTemp(mergeSortData);
            mergeSortTime.Stop();

            Sorts.Print(mergeSortData);
            Console.WriteLine($"{Environment.NewLine}Merge Sort Temp Array ===> {TimeSpan.FromTicks(mergeSortTime.ElapsedTicks).TotalMilliseconds }");
            #endregion

            #region Merge Sort Lists
            var mergeSortListData = DataGeneration.GetData(TotalRandomNumbers);
            var mergeSortListTime = Stopwatch.StartNew();
            var result = Sorts.MergeSort(mergeSortListData.ToList());
            mergeSortListTime.Stop();

            Sorts.Print(result);
            Console.WriteLine($"{Environment.NewLine}Merge Sort List ===> {TimeSpan.FromTicks(mergeSortListTime.ElapsedTicks).TotalMilliseconds }");
            #endregion

            #region Bubble Sort
            var bubbleSortData = DataGeneration.GetData(TotalRandomNumbers);
            var bubbleSortTime = Stopwatch.StartNew();
            Sorts.BubbleSort(bubbleSortData);
            bubbleSortTime.Stop();

            Sorts.Print(bubbleSortData);
            Console.WriteLine($"{Environment.NewLine}Bubble Sort ===> {TimeSpan.FromTicks(bubbleSortTime.ElapsedTicks).TotalMilliseconds }");
            #endregion

            #region Counting Sort
            var countingSortData = DataGeneration.GetData(TotalRandomNumbers);
            var countingSortTime = Stopwatch.StartNew();
            Sorts.CountingSort(countingSortData);
            countingSortTime.Stop();

            Sorts.Print(countingSortData);
            Console.WriteLine($"{Environment.NewLine}Counting Sort ===> {TimeSpan.FromTicks(countingSortTime.ElapsedTicks).TotalMilliseconds }");
            #endregion

            Console.ReadKey();
        }
    }
}