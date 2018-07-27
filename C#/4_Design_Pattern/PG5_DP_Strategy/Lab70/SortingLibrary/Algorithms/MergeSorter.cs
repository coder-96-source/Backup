using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingLibrary.Algorithms
{
    public class MergeSorter<T> : ISortable<T> where T : IComparable<T>
    {
        public void Sort(T[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException();
            }

            if (elements.Length < 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            MertSort(elements, 0, elements.Length - 1);
        }

        private void MertSort(T[] elements, int startIndex, int endIndex)
        {
            int middleIndex;

            if (endIndex - startIndex < 1)
            {
                return;
            }

            middleIndex = (startIndex + endIndex) / 2;

            MertSort(elements, startIndex, middleIndex);
            MertSort(elements, middleIndex + 1, endIndex);

            Merge(elements, startIndex, middleIndex, endIndex);
        }

        private void Merge(T[] elements, int startIndex, int middleIndex, int endIndex)
        {
            int leftIndex = startIndex;
            int rightIndex = middleIndex + 1;
            int destIndex = 0;

            var destnation = new List<T>();

            while (leftIndex <= middleIndex && rightIndex <= endIndex)
            {
                if (elements[leftIndex].CompareTo(elements[rightIndex]) < 0)
                {
                    destnation[destIndex] = elements[leftIndex];
                    leftIndex++;
                }
                else
                {
                    destnation[destIndex] = elements[rightIndex];
                    rightIndex++;
                }

                while (leftIndex <= middleIndex)
                {
                    destnation[destIndex++] = elements[leftIndex++];
                }

                while (rightIndex <= endIndex)
                {
                    destnation[destIndex++] = elements[rightIndex++];
                }

                destIndex = 0;
                for (int i = startIndex; i <= endIndex; i++)
                {
                    elements[i] = destnation[destIndex++];
                }
            }
        }
    }
}
