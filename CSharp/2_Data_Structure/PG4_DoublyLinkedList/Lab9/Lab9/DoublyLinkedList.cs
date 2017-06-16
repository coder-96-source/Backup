using System;

namespace Lab9
{
    public class DoublyLinkedList<T>
    {
        public DoublyLinkedList()
        {
            FirstNode = null;
            LastNode = null;
        }

        public Node<T> FirstNode { get; private set; }
        public Node<T> LastNode { get; private set; }

        public void Add(Node<T> newNode) //새 노드를 리스트의 마지막에 추가합니다.
        {
            if (IsEmpty())
            {
                FirstNode = LastNode = newNode;
            }
            else
            {
                LastNode.Next = newNode; //마지막 노드와 전 노드 상호 연결
                newNode.Prev = LastNode; //마지막 노드와 전 노드 상호 연결
                LastNode = LastNode.Next; //마지막 노드 포인터 이동
            }
        }
        public void Remove(Node<T> removeNode) //Remove 메서드의 파라미터에 지정된 노드를 리스트에서 삭제합니다.
        {
            if (IsEmpty())
            {
                throw new IndexOutOfRangeException();
            }

            if (FirstNode == removeNode)
            {
                FirstNode = FirstNode.Next;

                FirstNode.Prev = FirstNode ?? null;
            }
            else if (LastNode == removeNode)
            {
                LastNode = LastNode.Prev;

                LastNode.Next = LastNode ?? null;
            }
            else //중간 노드 삭제시
            {
                removeNode.Prev.Next = removeNode.Next;
                removeNode.Next.Prev = removeNode.Prev;
            }
        }
        public void AddAfter(Node<T> aheadNode, Node<T> newNode) //새 노드를 삽입 위치에 있는 노드 뒤에 삽입합니다.
        {
            aheadNode.Next.Prev = newNode; //뒷 노드와 새 노드 연결
            newNode.Next = aheadNode.Next; //뒷 노드와 새 노드 연결
            newNode.Prev = aheadNode; //앞 노드와 새 노드 연결
            aheadNode.Next = newNode; //앞 노드와 새 노드 연결
        }
        public void AddAfter(Node<T> aheadNode, T data) //데이타(노드)를 삽입 위치에 있는 노드 뒤에 삽입합니다.
        {
            Node<T> newNode = new Node<T>(data);

            aheadNode.Next.Prev = newNode; //뒷 노드와 새 노드 연결
            newNode.Next = aheadNode.Next; //뒷 노드와 새 노드 연결
            newNode.Prev = aheadNode; //앞 노드와 새 노드 연결
            aheadNode.Next = newNode; //앞 노드와 새 노드 연결
        }
        public Node<T> GetNode(int index) //리스트 상의 노드 위치로 해당 노드를 리턴합니다.
        {
            Node<T> current = FirstNode;
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
        public int Count() //리스트 상의 노드 갯수를 리턴합니다.
        {
            Node<T> current = FirstNode;
            int i = 0;

            while (current != null)
            {
                current = current.Next;
                i++;
            }

            return i;
        }
        public bool IsEmpty() //리스트가 비어있는지 확인합니다.
        {
            return (FirstNode == null);
        }
    }
}
