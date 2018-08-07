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
            var actions = new List<Func<string>>()
            {
                proxyHttp.RequestHttpBinDeleteMethod,
                proxyHttp.RequestHttpBinGetMethod,
                proxyHttp.RequestHttpBinPatchMethod,
                proxyHttp.RequestHttpBinPostMethod,
                proxyHttp.RequestHttpBinPutMethod
            };

            foreach (var action in actions) // Before cached
            {
                string result = action.Invoke();
                Console.WriteLine(result);
            }

            foreach (var action in actions) // After cached
            {
                string result = action.Invoke();
                Console.WriteLine(result);
            }
        }
    }
}
