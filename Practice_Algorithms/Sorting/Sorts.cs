using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorting
{
    public static class Sorts
    {
        public static void InsertionSort(IList<int> arr)
        {
            for (var current = 1; current < arr.Count; current++)
            {
                var index = current;
                var previous = current - 1;
                while (previous >= 0 && arr[previous] > arr[index])
                {
                    var temp = arr[previous];
                    arr[previous] = arr[index];
                    arr[index--] = temp;

                    previous--;
                }

                //for (var previous = current - 1; previous >= 0; previous--)
                //{
                //    if (arr[previous] <= arr[index]) continue;
                //    var temp = arr[previous];
                //    arr[previous] = arr[index];
                //    arr[index--] = temp;
                //}
            }
        }

        public static void SelectionSort(IList<int> arr)
        {
            for (var current = 0; current < arr.Count; current++)
            {
                var minIndex = current;
                for (var next = current + 1; next < arr.Count; next++)
                {
                    if (arr[next] > arr[minIndex]) continue;
                    minIndex = next;
                }

                var temp = arr[current];
                arr[current] = arr[minIndex];
                arr[minIndex] = temp;
            }
        }

        #region QuickSort
        public static void QuickSort(IList<int> arr, int min, int max)
        {
            DoQuickSort(arr, min, max);
        }

        private static void DoQuickSort(IList<int> arr, int min, int max)
        {
            if (min >= max) return;

            var pivot = arr[max];
            var left = min;
            var right = max - 1;

            while (left < right)
            {
                if (arr[left] >= pivot && arr[right] < pivot)
                {
                    var temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                    left++;
                }
                else if (arr[left] < pivot)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            if (arr[left] > pivot)
            {
                var leftValue = arr[left];
                arr[left] = pivot;
                arr[max] = leftValue;
            }

            DoQuickSort(arr, min, left - 1);
            DoQuickSort(arr, left + 1, max);
        }
        #endregion

        #region HeapSort
        public static void HeapSort(IList<int> arr)
        {
            BuildHeap(arr);
            HeapToSortedArray(arr);
        }

        private static void BuildHeap(IList<int> values)
        {
            // Start at index 1 because the values form a
            // trivial heap when only item 0 is in the tree.
            for (var i = 1; i < values.Count; i++)
            {
                // Add values[i] to the bottom of the heap.
                // Fix the heap from the bottom up.
                var child = i;
                for (; ; )
                {
                    var parent = (child - 1) / 2;

                    // Compare the value to its parent.
                    // If values[child] <= values[parent], the tree is a heap.
                    if (values[child] <= values[parent]) break;

                    // Swap the new value and its parent.
                    var temp = values[child];
                    values[child] = values[parent];
                    values[parent] = temp;

                    // Move up to the next level.
                    child = parent;
                }
            }
        }

        // Convert the heap into a sorted array.
        private static void HeapToSortedArray(IList<int> values)
        {
            // Loop through the array from back-to-front.
            for (var i = values.Count - 1; i > 0; i--)
            {
                // Swap values[0] and values[i].
                var temp = values[i];
                values[i] = values[0];
                values[0] = temp;

                // Fix the heap by pushing the root item down into the tree.
                var parent = 0;
                for (; ; )
                {
                    // Get the child indexes.
                    var child1 = 2 * parent + 1;
                    if (child1 >= i) break; // Outside of the current heap.

                    // If child2 is outside of the current heap, just use child1.
                    var child2 = child1 + 1;
                    if (child2 >= i) child2 = child1;

                    // Find the larger child.
                    var largerIndex = child1;
                    //var largerValue = values[child1];
                    if (values[largerIndex] < values[child2])
                    {
                        largerIndex = child2;
                        //largerValue = values[child2];
                    }

                    // If the larger child is <= the parent, it's a heap again.
                    if (values[largerIndex] <= values[parent]) break;

                    // Swap the parent with the larger child.
                    var largerValue = values[largerIndex];
                    values[largerIndex] = values[parent];
                    values[parent] = largerValue;
                    parent = largerIndex;
                }
            }
        }
        #endregion

        #region MergeSort
        #region With Temporal Array
        public static void MergeSortTemp(IList<int> values)
        {
            var temp = new int[values.Count];

            DoMergeSort(temp, values, 0, values.Count - 1);
        }

        private static void DoMergeSort(IList<int> temp, IList<int> values, int min, int max)
        {
            if (max - min + 1 < 2) return;

            var mid = (max + min) / 2;

            DoMergeSort(temp, values, min, mid);
            DoMergeSort(temp, values, mid + 1, max);

            var leftIndex = min;
            var rightIndex = mid + 1;

            for (var i = min; i <= max; i++)
            {
                int smallIndexValue;
                if (leftIndex > mid)
                {
                    // We ran out of left values. Use the next right value.
                    smallIndexValue = rightIndex;
                    rightIndex++;
                }
                else if (rightIndex > max)
                {
                    // We ran out of right values. Use the next left value.
                    smallIndexValue = leftIndex;
                    leftIndex++;
                }
                else
                {
                    // Use whichever value is smaller.
                    if (values[leftIndex] <= values[rightIndex])
                    {
                        // Use the left value.
                        smallIndexValue = leftIndex;
                        leftIndex++;
                    }
                    else
                    {
                        // Use the right value.
                        smallIndexValue = rightIndex;
                        rightIndex++;
                    }
                }

                // Move the selected value into the temp array.
                temp[i] = values[smallIndexValue];
            }

            for (var i = min; i <= max; i++)
            {
                values[i] = temp[i];

            }
        }
        #endregion

        #region With Lists
        public static List<int> MergeSort(List<int> arr)
        {
            if (arr.Count <= 1) return arr;

            var left = new List<int>();
            var right = new List<int>();

            for (var i = 0; i < arr.Count; i++)
            {
                if (i < arr.Count / 2)
                {
                    left.Add(arr[i]);
                }
                else
                {
                    right.Add(arr[i]);
                }
            }

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        private static List<int> Merge(IList<int> left, IList<int> right)
        {
            var result = new List<int>();

            while (left.Any() && right.Any())
            {
                if (left.FirstOrDefault() <= right.FirstOrDefault())
                {
                    result.Add(left.FirstOrDefault());
                    left.RemoveAt(0);
                }
                else
                {
                    result.Add(right.FirstOrDefault());
                    right.RemoveAt(0);
                }
            }

            while (left.Any())
            {
                result.Add(left.FirstOrDefault());
                left.RemoveAt(0);
            }

            while (right.Any())
            {
                result.Add(right.FirstOrDefault());
                right.RemoveAt(0);
            }

            return result;
        }
        #endregion
        #endregion

        public static void BubbleSort(IList<int> arr)
        {
            bool changes;

            do
            {
                changes = false;
                for (var i = 0; i < arr.Count - 1; i++)
                {
                    for (var j = i + 1; j < arr.Count; j++)
                    {
                        if (arr[j] < arr[i])
                        {
                            var temp = arr[j];
                            arr[j] = arr[i];
                            arr[i] = temp;
                            changes = true;
                        }
                    }

                }
            } while (changes);

        }

        public static void CountingSort(IList<int> arr)
        {
            var countingArray = new int[arr.Max() + 1];

            foreach (var t in arr)
            {
                countingArray[t]++;
            }

            var arrIndex = 0;

            for (var i = 0; i < countingArray.Length; i++)
            {
                for (var j = 0; j < countingArray[i]; j++)
                {
                    arr[arrIndex++] = i;
                }
            }
        }

        public static void Print(IEnumerable<int> array)
        {
            Console.WriteLine();
            foreach (var element in array)
            {
                Console.Write($"{element} ");
            }
        }
    }
}
//Another way to do bubble sort...
/*
 *  #region Bubblesort

        // Bubblesort.
        public static void Bubblesort(T[] values)
        {
            bool madeSwap = false;
            do
            {
                madeSwap = false;
                for (int i = 1; i < values.Length; i++)
                {
                    // See if values[i] < values[i - 1].
                    if (values[i].CompareTo(values[i - 1]) < 0)
                    {
                        // Swap values[i] and values[i - 1].
                        T temp = values[i];
                        values[i] = values[i - 1];
                        values[i - 1] = temp;
                        madeSwap = true;
                    }
                }
            } while (madeSwap);
        }
        
        #endregion Bubblesort

        #region Bubblesort2

        // Bubblesort2.
        public static void Bubblesort2(T[] values)
        {
            bool madeSwap = false;
            for (; ; )
            {
                // Swap down.
                madeSwap = false;
                for (int i = 1; i < values.Length; i++)
                {
                    // See if values[i] < values[i - 1].
                    if (values[i].CompareTo(values[i - 1]) < 0)
                    {
                        // Swap values[i] and values[i - 1].
                        T temp = values[i];
                        values[i] = values[i - 1];
                        values[i - 1] = temp;
                        madeSwap = true;
                    }
                }
                if (!madeSwap) break;

                // Swap up.
                madeSwap = false;
                for (int i = values.Length - 1; i > 0; i--)
                {
                    // See if values[i] < values[i - 1].
                    if (values[i].CompareTo(values[i - 1]) < 0)
                    {
                        // Swap values[i] and values[i - 1].
                        T temp = values[i];
                        values[i] = values[i - 1];
                        values[i - 1] = temp;
                        madeSwap = true;
                    }
                }
                if (!madeSwap) break;
            }
        }

        #endregion Bubblesort2
 */