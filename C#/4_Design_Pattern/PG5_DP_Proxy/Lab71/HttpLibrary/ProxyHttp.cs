using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpLibrary
{
    public class ProxyHttp : IHttpRequestable
    {
        private Lazy<SocketHttp> _socketHttp = new Lazy<SocketHttp>();
        private readonly Dictionary<string, string> _cacheDictionary = new Dictionary<string, string>();

        public ProxyHttp()
        {

        }

        public string RequestHttpBinGetMethod()
        {
            string result = null;

            result = _socketHttp.Value.RequestHttpBinGetMethod();

            return result;
        }
    }
}
