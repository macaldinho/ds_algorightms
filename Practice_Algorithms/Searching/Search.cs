using System;
using System.Linq;

namespace Searching
{
    public static class Search<T> where T : IComparable<T>
    {
        #region Linear Search
        public static int Linear(T[] arr, T target)
        {
            for (var i = 0; i < arr.Length; i++)
            {
                if (arr[i].CompareTo(target) == 0)
                {
                    return i;
                }
            }

            return -1;
        }
        #endregion

        #region Binary Search
        public static int Binary(T[] arr, T target)
        {
            Array.Sort(arr);

            var min = 0;
            var max = arr.Length - 1;

            while (min <= max)
            {
                var mid = (min + max) / 2;
                var diff = target.CompareTo(arr[mid]);

                switch (diff)
                {
                    case 0:
                        return mid;
                    case < 0:
                        max = mid - 1;
                        break;
                    default:
                        min = mid + 1;
                        break;
                }
            }

            return -1;
        }
        #endregion

        #region Interpolation Search
        public static int Interpolation(long[] arr, long target)
        {
            Array.Sort(arr);

            //var distance = target - arr[0];
            //var valueRange = arr[^1] - arr[0];
            //double fraction = distance / valueRange;
            //var indexRange = arr.Length - 1 - 0;
            //var estimate = (int)(0 + fraction * indexRange);

            var min = 0;
            var max = arr.Length - 1;
            var fraction = (target - arr[min]) / (double)(arr[max] - arr[0]);
            var guess = (int)((max - min) * fraction);
            if (guess < 0) return 0;
            if (guess > max) guess = max;

            if (target == arr[guess]) return guess;
            if (target < arr[guess]) max = guess;
            else min = guess;

            // Binary search from this point.
            while (min <= max)
            {
                var mid = (max + min) / 2;
                var diff = target.CompareTo(arr[mid]);
                switch (diff)
                {
                    case 0:
                        return mid;
                    case < 0:
                        max = mid - 1;
                        break;
                    default:
                        min = mid + 1;
                        break;
                }
            }

            return -1;
        }
        //public static int Interpolation(long[] arr, long target)
        //{
        //    Array.Sort(arr);

        //    //var distance = target - arr[0];
        //    //var valueRange = arr[^1] - arr[0];
        //    //double fraction = distance / valueRange;
        //    //var indexRange = arr.Length - 1 - 0;
        //    //var estimate = (int)(0 + fraction * indexRange);

        //    var min = 0;
        //    var max = arr.Length - 1;
        //    var fraction = (target - arr[min]) / (double)(arr[max] - arr[0]);
        //    var guess = (int)((max - min) * fraction);
        //    if (guess < 0) return 0;
        //    if (guess > max) guess = max;

        //    // Use an expanding binary search to bound the target.
        //    if (target == arr[guess]) return guess;
        //    if (target < arr[guess])
        //    {
        //        // Search down.
        //        max = guess;
        //        var offset = 1;
        //        while (target < arr[guess])
        //        {
        //            guess -= offset;
        //            if (guess < 0)
        //            {
        //                guess = 0;
        //                break;
        //            }
        //            offset *= 2;
        //        }
        //        min = guess;
        //    }
        //    else
        //    {
        //        // Search up.
        //        min = guess;
        //        var offset = 1;
        //        while (target > arr[guess])
        //        {
        //            guess += offset;
        //            if (guess > max)
        //            {
        //                guess = max;
        //                break;
        //            }
        //            offset *= 2;
        //        }
        //        max = guess;
        //    }

        //    // Binary search from this point.
        //    while (min <= max)
        //    {
        //        var mid = (max + min) / 2;
        //        var diff = target.CompareTo(arr[mid]);
        //        switch (diff)
        //        {
        //            case 0:
        //                return mid;
        //            case < 0:
        //                max = mid - 1;
        //                break;
        //            default:
        //                min = mid + 1;
        //                break;
        //        }
        //    }

        //    return -1;
        //}
        #endregion
    }
}