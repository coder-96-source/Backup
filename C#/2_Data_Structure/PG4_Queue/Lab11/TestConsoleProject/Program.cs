using System;
using Lab11;

namespace TestConsoleProject
{
    /* 이번 Lab에서는 Count 를 On the fly로 계산하는 방식이 아니라 Enq /Deq 에서 증감하는 방식을 취하였습니다.
     * 따라서, IsFull 과 IsEmpty 를 Count 에 의존하여 알아낼 수 있으므로, capacity + 1 만큼 공간을 만들 필요가 없습니다.
     * 만약 Count 증감을 하지 않는 경우에는 (이전처럼), 
     * 정해진 Capacity보다 +1 을 해야 Front/Rear 의 관계로서Full / Empty 를 구분할 수 있습니다.
     */
    class Program
    {
        static void Main(string[] args)
        {
            int qSize = 5;

            MyQueue<int> myQueue = new MyQueue<int>(qSize); //int[16] 생성

            //Enqueue()
            for(int i = 0; i < qSize * 2; i++)
            {
                int data = i + 1;

                myQueue.Enqueue(data);
                Console.Write("[{0}]", data);
            }

            //Count, Peek()
            Console.WriteLine("\nCount : {0} \t Peek : {1}\n\n", myQueue.Count, myQueue.Peek());

            //Dequeue(), Enqueue()
            Console.Write("Dequeue : ");
            for (int i = 0; i < qSize; i++)
            {
                Console.Write("[{0}]", myQueue.Dequeue());
            }
            Console.Write("\nEnqueue : ");
            for (int i = 0; i < qSize; i++)
            {
                int data = i + 11;

                myQueue.Enqueue(data);
                Console.Write("[{0}]", data);
            }
            Console.WriteLine("\n");

            //Dequeue(), Count
            for (int i = 0; i < qSize * 2; i++)
            {
                Console.WriteLine("DeQueue : [{0}] \t Count : [{1}]", myQueue.Dequeue(), myQueue.Count); ;
            }

            //myQueue.DeQueue(); IndexOutOfRangeException 발생!
        }
    }
}
