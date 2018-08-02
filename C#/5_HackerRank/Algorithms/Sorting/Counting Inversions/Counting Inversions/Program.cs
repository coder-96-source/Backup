using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counting_Inversions
{
    public class Program
    {
        private static long countInversions(int[] arr)
        {
            long swapCount = 0;
            MergeSort(arr, 0, arr.Length - 1, ref swapCount);

            return swapCount;
        }

        private static void MergeSort(int[] elements, int start, int end, ref long count)
        {
            if (start < end)
            {
                int middle = (start + end) / 2;

                MergeSort(elements, start, middle, ref count);
                MergeSort(elements, middle + 1, end, ref count);
                Merge(elements, start, middle, end, ref count);
            }
        }

        private static void Merge(int[] elements, int start, int middle, int end, ref long count)
        {
            int left = start;
            int right = middle + 1;
            int size = end - start + 1;
            int[] temp = new int[size];

            int index = 0;
            while (left <= middle && right <= end)
            {
                if (elements[left] <= elements[right])
                {
                    if (elements[left] != elements[right] && left - start - index > 0)
                        count += (left - start - index);
                    temp[index] = elements[left];
                    left++;
                }
                else
                {
                    if (right - start - index > 0)
                        count += (right - start - index);
                    temp[index] = elements[right];
                    right++;
                }
                index++;
            }

            if (middle - left + 1 > 0)
            {
                Array.Copy(elements, left, temp, index, middle - left + 1); // If while loop ended without copying left part to temp
                count += (left - index) * (end - right + 1);
            }
            Array.Copy(elements, right, temp, index, end - right + 1); // If while loop ended without copying right part to temp
            Array.Copy(temp, 0, elements, start, size);
        }

        public static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int t = Convert.ToInt32(Console.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                int n = Convert.ToInt32(Console.ReadLine());

                int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
                long result = countInversions(arr);

                textWriter.WriteLine(result);
            }

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
