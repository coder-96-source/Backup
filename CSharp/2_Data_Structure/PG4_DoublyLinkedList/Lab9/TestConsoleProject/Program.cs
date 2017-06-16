using System;
using Lab9;

namespace TestConsoleProject
{   /*
     * null값인 상태의 노드에 무언가(data 혹은 null)를 할당시 오류가 일어나는데 null 데이터를 가지게된 객체는
     * 다시 데이터 할당은 불가능하고 오로지 생성자를 통해서 데이터를 할당할때만 가능한가요?
     * 
     * Node 자체가 null 인데 무엇을 할당하려면 물론 NullReferenceException이 날 거구요
     * ex) Node n; n.Data = 1;
     * Node 객체는 있고, Data 속성만 변경할 경우에는 문제가 없습니다. 물론 Data 타입이 Reference 타입이어야 null 이 할당될 수 있고요.
     */
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }
        
        public static void Run()
        {
            DDLTest();
        }

        public static void DDLTest()
        {
            DoublyLinkedList<int> myDDL = new DoublyLinkedList<int>();

            Show(myDDL);

            myDDL.Add(new Node<int>(0)); //node1 삽입
            Show(myDDL);
            myDDL.Add(new Node<int>(10)); //node2 삽입
            Show(myDDL);
            myDDL.Add(new Node<int>(30)); //node3 삽입
            Show(myDDL);
            myDDL.Add(new Node<int>(40)); //node4 삽입
            Show(myDDL);

            myDDL.AddAfter(myDDL.GetNode(1), new Node<int>(20)); //node2 뒤에 node3 삽입
            Show(myDDL);

            Console.WriteLine("LastNode remove");
            myDDL.Remove(myDDL.GetNode(4));
            Show(myDDL);

            Console.WriteLine("MidNode remove");
            myDDL.Remove(myDDL.GetNode(2));
            Show(myDDL);

            Console.WriteLine("FirstNode remove");
            myDDL.Remove(myDDL.GetNode(0));
            Show(myDDL);

            Console.WriteLine("All Node remove");
            myDDL.Remove(myDDL.GetNode(0));
            myDDL.Remove(myDDL.GetNode(0));    
            Show(myDDL);        
        }
        public static void Show(DoublyLinkedList<int> myDDL)
        {
            if (myDDL.IsEmpty())
            {
                Console.WriteLine("FirstNode = null");
                Console.WriteLine("LastNode  = null");
                Console.WriteLine("Count     = {0}", myDDL.Count());
                Console.WriteLine("[null]\n");
            }
            else
            {
                Console.WriteLine("FirstNode = {0}", myDDL.FirstNode.Data);
                Console.WriteLine("LastNode  = {0}", myDDL.LastNode.Data);
                Console.WriteLine("Count     = {0}", myDDL.Count());

                FrontSideLoop(myDDL);
                //BackSideLoop(myDDL);
            }
        }
        public static void FrontSideLoop(DoublyLinkedList<int> myDDL)
        {
            Node<int> current = myDDL.FirstNode;

            while (current != null)
            {
                Console.Write("[{0}]", current.Data);

                current = current.Next;
            }
            Console.WriteLine("\n");
        }
        public static void BackSideLoop(DoublyLinkedList<int> myDDL)
        {
            Node<int> current = myDDL.LastNode;

            while (current != null)
            {
                Console.Write("[{0}]", current.Data);

                current = current.Prev;
            }
            Console.WriteLine("\n");
        }
    }
}
