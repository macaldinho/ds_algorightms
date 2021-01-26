using System;

namespace Searching
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Linear Search
            var linearData = new[] { 4, 6, 5, 3, 1, 2, 8, 9, 7 };
            var linearIndex = Search<int>.Linear(linearData, 11);

            Console.WriteLine($"{(linearIndex > 0 ? linearIndex : "Value not found")}");
            #endregion

            #region Binary Search
            var binaryData = new[] { 0, 4, 7, 9, 12, 14, 18, 25, 27, 36, 46, 50, 64, 79, 88 };
            var binaryIndex = Search<int>.Binary(binaryData, 77);

            Console.WriteLine($"{(binaryIndex > 0 ? binaryIndex : "Value not found")}");
            #endregion

            #region Interpolation Search
            var interpolationData = new long[] { 0, 7, 12, 17, 21, 26, 31, 33, 40, 43, 49, 51, 64, 66, 72, 73, 81, 87, 95, 99,100,110,111,115,117 };
            var interpolationIndex = Search<int>.Interpolation(interpolationData, 110);

            Console.WriteLine($"{(interpolationIndex > 0 ? interpolationIndex : "Value not found")}");
            #endregion
        }
    }
}