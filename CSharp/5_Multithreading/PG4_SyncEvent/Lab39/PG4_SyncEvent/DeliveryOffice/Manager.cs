using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PG4_SyncEvent
{
    public class Manager
    {
        private AutoResetEvent _evt;

        public Manager()
        {
            this._evt = new AutoResetEvent(false);
        }

        public AutoResetEvent Evt { get { return this._evt; } }

        public void Ring()
        {
            this.Evt.Set();
        }
    }
}
