using System;

namespace Lab10
{
    public class ListBaseStack<T> : IStack<T>
    {
        public ListBaseStack()
        {
            Top = null;
        }

        private Node<T> Top { get; set; }

        public void Push(T data) //Stack 에 새 값을 추가합니다.
        {
            Node<T> newNode = new Node<T>(data);   

            if (IsEmpty())
            {
                Top = newNode;
            }
            else
            {
                newNode.Next = Top;
                Top = newNode;
            }
        }
        public T Pop() //최상위에 값을 리턴하고 Stack에서 삭제합니다.
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }
            else
            {
                Node<T> popNode = Top;
                Top = Top.Next;

                return popNode.Data;
            }
        }
        public T Peek() //최상위에 값을 리턴하고 Stack에서는 삭제하지 않습니다.
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }
            else
            {
                return Top.Data;
            }
        }
        public int Count() //Stack에 있는 요소수를 리턴합니다.
        {
            Node<T> current = Top;
            int i = 0;

            while (current != null)
            {
                current = current.Next;
                i++;
            }

            return i;
        }
        public bool IsEmpty() //Stack 이 비어있는지 bool 리턴합니다.
        {
            return (Top == null);
        }
    }
}
