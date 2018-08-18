using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkLibrary.Networks
{
    public class BluetoothNetwork : INetwork
    {
        private bool _isConnected;

        public BluetoothNetwork()
        {
            this._isConnected = false;
        }

        public void Connect()
        {
            this._isConnected = true;
        }

        public void Disconnect()
        {
            this._isConnected = false;
        }

        public void Receive()
        {
            Console.WriteLine($"{nameof(BluetoothNetwork)} receives ");
        }

        public void Send()
        {
            Console.WriteLine($"{nameof(BluetoothNetwork)} sends ");
        }

        // Flag: Has Dispose already been called?
        bool disposed = false;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        ~BluetoothNetwork()
        {
            Dispose(false);
        }
    }
}
