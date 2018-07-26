using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG5_DP_Strategy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var randomNumbers = GetRandomNumbers(100);
            PrintArray(randomNumbers);

            //RunBubbleSorter(randomNumbers);
            //RunInsertionSorter(randomNumbers);
            RunQuickSorter(randomNumbers);
        }

        private static void RunBubbleSorter(int[] randomNumbers)
        {
            var bubbleSorter = new SortingLibrary.BubbleSorter<int>();
            bubbleSorter.Sort(randomNumbers);
            PrintArray(randomNumbers);
        }

        private static void RunInsertionSorter(int[] randomNumbers)
        {
            var insertionSorter = new SortingLibrary.InsertionSorter<int>();
            insertionSorter.Sort(randomNumbers);
            PrintArray(randomNumbers);
        }

        private static void RunQuickSorter(int[] randomNumbers)
        {
            var quickSorter = new SortingLibrary.QuickSorter<int>();
            quickSorter.Sort(randomNumbers);
            PrintArray(randomNumbers);
        }

        private static int[] GetRandomNumbers(int size)
        {
            var rand = new Random();
            int[] randomArray = new int[size];

            for (int i = 0; i < randomArray.Length; i++)
            {
                randomArray[i] = rand.Next() % 100;
            }

            return randomArray;
        }

        private static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
        }
    }
}
