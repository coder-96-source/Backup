using System;

namespace SinglyLinkedList
{
    public class List<T>
    {
        public List()
        {
            Head = null;
        }

        public Node<T> Head { get; private set; }

        public void Add(Node<T> newNode) //새 노드를 리스트의 마지막에 추가합니다
        {
            if (IsEmpty())
            {
                Head = newNode;
            }    
            else
            {
                Node<T> current = Head;

                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }
        public void Remove(Node<T> deleteNode) //메서드의 파라미터에 지정된 노드를 리스트에서 삭제합니다.
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }

            if (Head == deleteNode)
            {
                Head = Head.Next;
            }
            else
            {
                Node<T> current = Head;

                while (current != null)
                {
                    if (current.Next == deleteNode)
                    {
                        current.Next = deleteNode.Next;
                    }
                    current = current.Next;
                }
            }
        }
        public void AddAfter(Node<T> aheadNode, Node<T> newNode) //새 노드를 삽입 위치에 있는 노드 뒤에 삽입합니다.
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }

            newNode.Next = aheadNode.Next;
            aheadNode.Next = newNode;
        }
        public Node<T> GetNode(int index) //리스트 상의 노드 위치로 해당 노드를 리턴합니다.
        {
            Node<T> current = Head;
            int i = 0;

            while (current != null)
            {
                if (i == index)
                {
                    break;
                }
                current = current.Next;
                i++;
            }
            
            return current;           
        }    
        public int Count() //리스트 상의 노드 갯수를 리턴합니다
        {
            Node<T> current = Head;
            int number = 0;

            while( current != null )
            {
                current = current.Next;
                number += 1;
            }

            return number;
        }
        public bool IsEmpty() //리스트가 비어있는지 확인합니다.
        {
            return Head == null;
        }
    }
}
