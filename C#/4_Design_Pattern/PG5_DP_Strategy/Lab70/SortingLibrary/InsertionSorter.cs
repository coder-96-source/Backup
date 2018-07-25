using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingLibrary
{
    public class InsertionSorter<T> : ISortable<T> where T : IComparable
    {
        public T[] Sort(T[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException();
            }

            for (int i = 1; i < elements.Length; i++)
            {
                int startIndex = i;
                while (startIndex > 0)
                {
                    if (elements[startIndex].CompareTo(elements[startIndex - 1]) < 0)
                    {
                        Swap(elements, startIndex, startIndex - 1);
                    }
                    startIndex--;
                }
            }

            return elements;
        }


        public void Swap(T[] elements, int i, int j)
        {
            T temp = elements[i];
            elements[i] = elements[j];
            elements[j] = temp;
        }
    }
}
