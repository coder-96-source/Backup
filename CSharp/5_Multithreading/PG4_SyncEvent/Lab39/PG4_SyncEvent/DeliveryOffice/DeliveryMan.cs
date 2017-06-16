using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PG4_SyncEvent
{
    public class DeliveryMan
    {
        private int _id;
        private AutoResetEvent _resetEvt;

        public DeliveryMan(int id, AutoResetEvent evt)
        {
            this._id = id;
            this._resetEvt = evt;
        }

        public int Id { get { return this._id; } }

        public void Delever()
        {
            while (true)
            {
                this._resetEvt.WaitOne(); // Wait for AutoResetEvent
                Console.WriteLine("Worker : {0}     DeliveryTime = {1}", this._id, DateTime.Now); // Print id and delivery time
                Thread.Sleep(1000); // Wait for 1sec
            }
        }
    }
}
