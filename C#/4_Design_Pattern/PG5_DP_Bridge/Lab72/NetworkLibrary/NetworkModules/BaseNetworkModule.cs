using NetworkLibrary.Networks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkLibrary.NetworkModules
{
    public abstract class BaseNetworkModule
    {
        protected INetwork _network;

        public BaseNetworkModule(INetwork network)
        {
            this._network = network;
        }
    }
}
