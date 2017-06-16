using System;
using SinglyLinkedList;

namespace TestConsoleProject
{
    /* GetNode()와 같이 return type이 Node인 경우, 사용자가 null 을 체크할 수 있게 반환 값을 null로 해주는 것이 좋다.
     * 
     * Method안 변수는 local variable, not a field. (field는 class 소속)
     * 메모리가 할당되는 경우와 같이 Burden이 되는 작업이 있다면 체크를 먼저하는게 좋습니다. 
     * 그리고 요즘은 (옛날의 C 등에서와 달리) 변수선언과 동시에 사용하기 때문에, 
     * 미리 변수를 선언해야하는 특별한 경우가 아니라면 사용시 해 주는것도 좋습니다.
     *
     * 각 Data Structure의 head, front, rear들은 implantation detail 입니다.
     * 
     * Node 객체의 Data, Next 속성들은 Linked List 를 사용하는 모든 API 사용자가 사용해야 하므로 public 으로 만드는 것이 좋습니다.
     * 지금처럼 List.cs 밖에서 별도로 만드는 것이 좋습니다.
     */
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }
        public static void Run()
        {
            Console.WriteLine("-----------------List-----------------");
            ListTest();
        }

        public static void ListTest()
        {
            List<int> testList = new List<int>();

            //Add() test
            testList.Add(new Node<int>(10));
            testList.Add(new Node<int>(20));
            testList.Add(new Node<int>(40));
            testList.Add(new Node<int>(50));

            //AddAfter() test
            testList.AddAfter(testList.GetNode(1), new Node<int>(30)); //2번 노드 뒤에 3번 노드 삽입
            Console.WriteLine("default list");
            ListShow(testList);

            //Remove() & Count() & GetNode test
            Console.WriteLine("deleting last node");
            testList.Remove(testList.GetNode(4));
            ListShow(testList);

            Console.WriteLine("deleting mid node");
            testList.Remove(testList.GetNode(1));
            ListShow(testList);

            for(int i=0; i<3; i++)
            {
                Console.WriteLine("deleting first node");
                testList.Remove(testList.GetNode(0));
                ListShow(testList);
            }
        }
        public static bool ListShow(List<int> list)
        {
            if (list.IsEmpty())
            {
                Console.WriteLine("[Head]  = null");
                Console.WriteLine("[Count] = {0}", list.Count());
                Console.WriteLine("[null]");
                return true;
            }
            Node<int> current = list.Head;

            Console.WriteLine("[Head]  = {0}", list.Head.Data);
            Console.WriteLine("[Count] = {0}", list.Count());
            while (current != null)
            {
                Console.Write("[{0}]", current.Data);
                current = current.Next;
            }
            Console.WriteLine();
            Console.WriteLine();
            return true;
        }     
    }
}
