using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG3_MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            // test
            int[] array = new int[] { 5, 4, 3, 2, 1, 10, 9, 8, 7, 6 };

            Console.WriteLine("Unsorted");
            foreach (int v in array)
            {
                Console.WriteLine(v);
            }

            MergeSort.MergeSorter.MergeSort(array);
            Console.WriteLine("Sorted");
            foreach (int v in array)
            {
                Console.WriteLine(v);
            }
        }
    }
}
