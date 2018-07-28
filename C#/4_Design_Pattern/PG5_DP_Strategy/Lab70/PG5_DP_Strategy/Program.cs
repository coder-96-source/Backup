using SortingLibrary.Algorithms;
using SortingLibrary;
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

            var sorters = new List<ISortable<int>>()
            {
                //new BubbleSorter<int>(),
                //new InsertionSorter<int>(),
                new QuickSorter<int>(),
                //new MergeSorter<int>()
            };

            // var randomNumbers = GetRandomNumbers(10);
            var randomNumbers = new int[] { 10, 80, 30, 90, 50, 60, 70 };
            foreach (var s in sorters)
            {
                var sorter = new Sorter<int>(s);
                var numbers = randomNumbers.Clone() as int[]; // Shallow copy from random 

                PrintArray(numbers); // Before sorting
                var ts = sorter.GetSortingTime(numbers);
                PrintArray(numbers); // After sorting

                // Print runtime
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                Console.WriteLine($"{s.GetType().Name} RunTime {elapsedTime}");
            }
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
                Console.Write($"[{array[i]}]");
            }
            Console.WriteLine();
        }
    }
}
