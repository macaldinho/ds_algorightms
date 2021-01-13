using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Basic_Algorithms
{
    public static class BasicAlgorithms
    {
        //Greatest Common Divisor
        public static int Gcd(int a, int b)
        {
            while (b != 0)
            {
                var remainder = a % b;
                a = b;
                b = remainder;
            }

            return a;
        }

        public static int RecursiveGcd(int a, int b)
        {
            if (b == 0) return a;
            return RecursiveGcd(b, a % b);

        }

        //Least Common multiple
        public static int Lcm(int a, int b)
        {
            //var lcm = (a * b) / Gcd(a, b);
            var lcm = (a / Gcd(a, b)) * b;

            return lcm;
        }

        public static IEnumerable<long> PrimeFactorization(long number)
        {
            //Big O Analysis
            //It takes Log2(n) bits to represent the number n
            //N = Log2(n)
            // n = 2^N

            //O(√n)
            //n=2^N
            //O(√2↑N)

            var factors = new List<long>();

            while (number % 2 == 0)
            {
                factors.Add(2);
                number /= 2;
            }

            var factor = 3;
            var stopAt = (long)Math.Sqrt(number);

            while (factor <= stopAt)
            {
                while (number % factor == 0)
                {
                    factors.Add(factor);
                    number /= factor;
                    stopAt = (long)Math.Sqrt(number);
                }
                factor += 2;
            }
            if (number > 1)
            {
                factors.Add(number);
            }

            return factors;
        }

        public static IEnumerable<int> SieveOfEratosthenesAlgorithm(int maxNumber)
        {
            var result = new List<int>();
            var isPrime = Enumerable.Repeat(true, maxNumber + 1).ToArray();
            isPrime[1] = false;

            //cross out multiples of 2
            for (var i = 4; i <= maxNumber; i += 2)
            {
                isPrime[i] = false;
            }

            //Then we start the loop in 3 and increments by 2 so we get only odd values, and this loop runs until √maxNumber
            for (var p = 3; p <= Math.Sqrt(maxNumber); p += 2)
            {
                if (!isPrime[p]) continue;
                //if number is prime then we loop initializing the value in p^2 so we start crossing the values started on this multiple,
                //then we increment value of multiple plus 2 times p so we consider only odd multiples of p
                for (var multiple = p * p; multiple <= maxNumber; multiple += 2 * p)
                {
                    isPrime[multiple] = false;

                }

            }

            for (var i = 2; i <= maxNumber; i++)
            {
                if (isPrime[i])
                {
                    result.Add(i);
                }
            }

            return result;
        }
    }
}