using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkLibrary.Networks
{
    public interface INetwork : IDisposable
    {
        void Connect();
        void Disconnect();
        void Send();
        void Receive();
    }
}
