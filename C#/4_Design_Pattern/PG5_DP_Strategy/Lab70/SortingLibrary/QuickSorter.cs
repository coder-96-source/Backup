using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingLibrary
{
    public class QuickSorter<T> : ISortable<T> where T : IComparable<T>
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

            QuickSort(elements, 0, elements.Length - 1);
        }

        private void QuickSort(T[] elements, int left, int right)
        {
            int i = left, j = right;

            Partitioning(elements, ref i, ref j);

            if (left < j)
            {
                QuickSort(elements, left, j);
            }

            if (i < right)
            {
                QuickSort(elements, i, right);
            }
        }

        private void Partitioning(T[] elements, ref int i, ref int j)
        {
            T pivot = elements[(i + j) / 2];

            while (i <= j)
            {
                while (elements[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (elements[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    Swap(elements, i++, j--);
                }
            }
        }

        private void Swap(T[] elements, int i, int j)
        {
            T temp = elements[i];
            elements[i] = elements[j];
            elements[j] = temp;
        }
    }
}
