using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sherlock_and_Cost
{
    class Program
    {
        // https://www.hackerrank.com/challenges/sherlock-and-cost/problem
        static void Main(string[] args)
        {
            int t = Int32.Parse(Console.ReadLine()); // t, the number of test cases
            for (int c = 0; c < t; c++)
            {
                // set data
                long size = long.Parse(Console.ReadLine()); // size of array
                int[] arrayB = new int[size];
                var elements = Console.ReadLine().Split(' ');
                for (int i = 0; i < arrayB.Length; i++)
                {
                    arrayB[i] = Int32.Parse(elements[i]);
                }

                // 
                int[] arrayA = new int[size];
                arrayA[0] = arrayB[0] < arrayB[1] ? 1 : arrayB[0]; // set first element
                for (int i = 1; i < arrayA.Length; i++)
                {
                    arrayA[i] = arrayB[i - 1] < arrayB[i] ? arrayB[i] : 1;
                }

                long sum = 0;
                for (int i = 0; i < arrayA.Length - 1; i++)
                {
                    sum += Math.Abs(arrayA[i] - arrayA[i + 1]);
                }
                Console.WriteLine(sum);


                /*
                int[] arrayA = new int[size];
                for (int i = 0; i < size - 1; i++)
                {
                    arrayA[i] = arrayB[i] < arrayB[i + 1] ? 1 : arrayB[i];
                }
                arrayA[size - 1] = arrayA[size - 2] == 1 ? arrayB[size - 1] : 1;

                double sum = 0;
                for (int i = 0; i < size - 1; i++)
                {
                    sum += Math.Abs(arrayA[i] - arrayA[i + 1]);
                }
                Console.WriteLine(sum); 
                */
            }
        }
    }
}
