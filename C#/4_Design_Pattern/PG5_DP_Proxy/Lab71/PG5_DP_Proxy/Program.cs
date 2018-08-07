using HttpLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG5_DP_Proxy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var proxyHttp = new ProxyHttp();
            var result = proxyHttp.RequestHttpBinGetMethod();
        }
    }
}
