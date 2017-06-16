using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PG4_Sync
{
    /* 쓰레드들이 공유된 자원(예를 들어 객체 필드)을 동시에 접근하는 것을 막고, 각 쓰레드들이 순차적으로 혹은 제한적으로 접근하도록 하는 것이 쓰레드 동기화 (Thread Synchronization)이다. => Thread-Safe
     * (1) Locking으로 공유 리소스에 대한 접근을 제한하는 방식으로 C# lock, Monitor, Mutex, Semaphore, SpinLock, ReaderWriterLock 등이 사용되며, 
     * (2) 타 쓰레드에 신호(Signal)을 보내 쓰레드 흐름을 제어하는 방식으로 AutoResetEvent, ManualResetEvent, CountdownEvent 등이 있다.
     * 
     * Monitor Class의 Wait() Pulse()
     * Wait() 메서드는 현재 쓰레드를 잠시 중지하고, lock을 Release한 후, 다른 쓰레드로부터 Pulse 신호가 올 때까지 대기한다.
     * Wait에서 lock 이 Release 되었으므로 다른 쓰레드가 lock을 획득하고 작업을 실행한다.
     * 다른 쓰레드가 자신의 작업을 마치고 Pulse() 메서드를 호출하면 대기중인 쓰레드는 lock을 획득하고 계속 다음 작업을 실행한다.
     * 예를들어, Dequeue가 되어야 하는 상황에서 resource가 없을 때, Wait()으로 대기하며, 다시 자원을 넣어주며 Pulse()로 대기를 끊어주는 역활을 할 수 있다.
     */
    class Program
    {
        private const int RUNNING_TIME = 180;
        private const int WRITE_TIME = 1 * 1000; // 1 sec

        private bool running;
        private object thisLock;
        private Queue<int> sharedQueue;

        static void Main(string[] args)
        {
            new Program().Run();
        }

        private void Run()
        {
            this.running = true;
            this.sharedQueue = new Queue<int>();
            this.thisLock = new object();

            new Thread(ReadQueue).Start();

            for (int i = 1; i <= 180; i++)
            {
                WriteQueue(i);
            }
            this.running = false;
        }

        private void WriteQueue(int data) // lock() 사용
        {
            lock (this.thisLock)
            {
                this.sharedQueue.Enqueue(data);
                Thread.Sleep(WRITE_TIME);
                Console.WriteLine("Time Counting : {0} sec", data);
            }
        }
        private void ReadQueue() // Monitor class 사용
        {
            Random rand = new Random();

            while (this.running)
            {
                int randomTime = rand.Next(1, 10) * 1000; // 1~10 sec

                Thread.Sleep(randomTime);
                Monitor.Enter(this.thisLock);
                try
                {
                    foreach (int data in this.sharedQueue)
                    {
                        Console.Write(data);
                    }
                    Console.WriteLine();
                }
                finally
                {
                    Monitor.Exit(this.thisLock);
                }
            }
        }
    }
}
