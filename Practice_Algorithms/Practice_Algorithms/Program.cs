using System;
using Algorithms.Basic_Algorithms;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(BasicAlgorithms.Gcd(66, 78));
            Console.WriteLine(BasicAlgorithms.Lcm(12, 15));
            Console.WriteLine(string.Join(" x ", BasicAlgorithms.PrimeFactorization(11)));
            Console.WriteLine(string.Join(",", BasicAlgorithms.SieveOfEratosthenesAlgorithm(10000)));

            Console.ReadKey();
        }
    }
}
