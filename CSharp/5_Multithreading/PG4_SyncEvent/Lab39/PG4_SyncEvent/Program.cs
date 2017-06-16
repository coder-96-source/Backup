using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PG4_SyncEvent
{
    class Program
    {
        private const int DELIVERYMAN_NUM = 10;
        private const int RING_NUM = 20;

        private static void Main(string[] args)
        {
            Manager managerA = new Manager();

            for (int i = 0; i < DELIVERYMAN_NUM; i++)
            {
                new Task((p) => 
                {
                    new DeliveryMan((int)p, managerA.Evt).Delever();
                }, i).Start();
            }
            
            for (int i = 0; i < RING_NUM; i++)
            {
                managerA.Ring();
                Thread.Sleep(1000);
            }
        }
    }
}
