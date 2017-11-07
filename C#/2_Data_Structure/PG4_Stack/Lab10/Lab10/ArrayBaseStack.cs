using System;

namespace Lab10
{
    public class ArrayBaseStack<T> : IStack<T>
    {
        private const int StackLength = 16;
        private T[] stack;

        public ArrayBaseStack()
        {
            Top = -1;
            stack = new T[StackLength];
        }

        private int Top { get; set; } // data가 아닌 index를 위한 property

        public void Push(T newData) //Stack 에 새 값을 추가합니다.
        {
            if (IsFull())
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                stack[++Top] = newData;
            }
        }
        public T Pop() //최상위에 값을 리턴하고 Stack에서 삭제합니다.
        {
            if (IsEmpty())
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                return stack[Top--];
            }
        }
        public T Peek() //최상위에 값을 리턴하고 Stack에서는 삭제하지 않습니다.
        {
            if (IsEmpty())
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                return stack[Top];
            }
        }
        public int Count() //Stack에 있는 요소수를 리턴합니다.
        {
            return (Top + 1);
        }
        public bool IsEmpty() //Stack 이 비어있는지 bool 리턴합니다.
        {
            return (Top == -1);
        }
        public bool IsFull() //Stack 이 꽉 차있는지 bool 리턴합니다
        {
            return (Top >= StackLength - 1);
        } 
    }
}
