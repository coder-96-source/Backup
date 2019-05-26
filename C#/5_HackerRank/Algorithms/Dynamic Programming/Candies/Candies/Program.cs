using System;
using System.IO;
using System.Linq;

namespace Candies
{
    internal class Program
    {
        private static long candies(int n, int[] arr)
        {
            long[] candies = new long[arr.Length];
            long totalCandies = 0;

            // Left to right
            candies[0] = 1;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                candies[i + 1] = arr[i] < arr[i + 1]
                    ? candies[i] + 1
                    : 1;
            }

            // Right to left
            totalCandies = candies[arr.Length - 1];
            for (int i = arr.Length - 1; i > 0; i--)
            {
                if (arr[i - 1] > arr[i])
                {
                    candies[i - 1] = Math.Max(candies[i - 1], candies[i] + 1);
                }

                totalCandies += candies[i - 1];
            }

            return totalCandies;
        }

        private static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            //int n = Convert.ToInt32(Console.ReadLine());

            //int[] arr = new int[n];

            //for (int i = 0; i < n; i++)
            //{
            //    int arrItem = Convert.ToInt32(Console.ReadLine());
            //    arr[i] = arrItem;
            //}
            //int n = 16387;
            //int[] arr = File.ReadAllLines(@"C:\Users\kims0\Desktop\Sample.txt").Select(s => Convert.ToInt32(s)).ToArray();

            int n = 11;
            int[] arr = new int[] { 9, 2, 3, 4, 6, 5, 4, 3, 2, 2, 2 };
            long result = candies(n, arr);

            //textWriter.WriteLine(result);

            Console.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
