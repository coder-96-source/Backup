using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Big_Sorting
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] unsorted = new string[n];
            for (int unsorted_i = 0; unsorted_i < n; unsorted_i++)
            {
                unsorted[unsorted_i] = Console.ReadLine();
            }

            // Bubble Sort
            int endIndex = unsorted.Count() - 1;
            bool flag = true;

            for (int i = 0; i < unsorted.Count() - 1; i++) // do as much as n-1
            {
                while (flag) // to avoid unnecessary loop
                {
                    flag = false; // set flag as false to escape loop

                    for (int j = 0; j < endIndex; j++)
                    {
                        var front = Convert.ToInt64(unsorted[j]);
                        var back = Convert.ToInt64(unsorted[j + 1]);
                        if (front.CompareTo(back) > 0)
                        {
                            // Swap
                            var temp = unsorted[j];
                            unsorted[j] = unsorted[j + 1];
                            unsorted[j + 1] = temp;
                            flag = true; // set flag as true to keep looping
                        }
                    }
                    endIndex--;
                }
            }
            foreach (var s in unsorted)
            {
                Console.WriteLine(s);
            }
        }
    }
}
