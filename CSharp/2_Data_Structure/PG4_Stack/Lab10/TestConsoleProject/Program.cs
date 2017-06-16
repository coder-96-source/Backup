using System;
using Lab10;

namespace TestConsoleProject
{
    /* 1. 초기 Array기반 자료구조는 16으로 사이즈를 설정한다.
     * 2. IsEmpty()에 대해서 return Node는 null로, return T는 default(T)가 아닌 exception throw를 한다. (ApplicationException, invalidoperationexception)
     */
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        public static void Run()
        {
            Console.WriteLine("----------ListBaseStack----------");
            ListBaseStackTest();
            Console.WriteLine("\n\n----------ArrayBaseStack----------");
            ArrayBaseStackTest();
        }
        public static void ListBaseStackTest()
        {
            IStack<int> myStack = StackFactory<int>.GetStack("list");
            
            //Push()
            Console.WriteLine("Push");
            for (int i = 1; i <= 5; i++)
            {
                int data = i * 10;

                myStack.Push(data);
                Console.WriteLine("[{0}]", data);
            }
            ListBaseStackShow(myStack);

            //Peek()
            Console.WriteLine("Peek() => {0}", myStack.Peek());
            ListBaseStackShow(myStack);

            //Pop()
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Pop() => {0}", myStack.Pop());
                ListBaseStackShow(myStack);
            }
        }
        public static bool ListBaseStackShow<T>(IStack<T> myStack)
        {           
            if (myStack.IsEmpty())
            {
                Console.WriteLine("COUNT = {0}", myStack.Count());
                return true;
            }
            else
            {
                Node<int> current = null;

                Console.WriteLine("COUNT = {0}", myStack.Count());
                while (current != null)
                {
                    Console.WriteLine("[{0}]", current.Data);

                    current = current.Next;
                }
                Console.WriteLine();
                return true;
            }
        }

        public static void ArrayBaseStackTest()
        {
            IStack<int> myStack = StackFactory<int>.GetStack("array");

            //Push()
            Console.WriteLine("Push");
            for (int i = 1; i <= 5; i++)
            {
                int data = i * 10;

                myStack.Push(data);
                Console.WriteLine("[{0}]", data);
            }
            ArrayBaseStackShow(myStack);

            //Peek()
            Console.WriteLine("[PEEK]  = {0}", myStack.Peek());
            ArrayBaseStackShow(myStack);

            //Pop()
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("[POP]   = {0}", myStack.Pop());
                ArrayBaseStackShow(myStack);
            } 
        }
        public static void ArrayBaseStackShow<T>(IStack<T> myStack)
        {
            if (myStack.IsEmpty())
            {
                Console.WriteLine("[TOP]   = Empty");
                Console.WriteLine("[COUNT] = {0}", myStack.Count());
            }
            else
            {
                Console.WriteLine("[COUNT] = {0}", myStack.Count());
            }
            Console.WriteLine();
        }
    }
}
