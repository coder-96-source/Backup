using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HttpLibrary
{
    internal class SocketHttp : IHttpRequestable
    {
        public SocketHttp()
        {

        }

        public string RequestHttpBinDeleteMethod()
        {
            string result = null;
            string httpRawData = @"DELETE http://httpbin.org/delete HTTP/1.1
Origin: http://httpbin.org
Referer: http://httpbin.org/
User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.140 Safari/537.36 Edge/17.17134
accept: application/json
Accept-Language: en-US,en;q=0.7,ko;q=0.3
Accept-Encoding: gzip, deflate
Content-Length: 0
Host: httpbin.org
Connection: Keep-Alive
Pragma: no-cache
Cookie: _gauges_unique_hour=1; _gauges_unique_month=1; _gauges_unique_day=1; _gauges_unique=1; _gauges_unique_year=1

";

            result = SendHttpBinRequest(httpRawData);

            return result;
        }

        public string RequestHttpBinGetMethod()
        {
            string result = null;
            string httpRawData = @"GET http://httpbin.org/get HTTP/1.1
Host: httpbin.org
Connection: keep-alive
Upgrade-Insecure-Requests: 1
User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.84 Safari/537.36
Accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8
Accept-Encoding: gzip, deflate
Accept-Language: en-US,en;q=0.9

";

            result = SendHttpBinRequest(httpRawData);

            return result;
        }

        public string RequestHttpBinPatchMethod()
        {
            string result = null;
            string httpRawData = @"PATCH http://httpbin.org/patch HTTP/1.1
Origin: http://httpbin.org
Referer: http://httpbin.org/
User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.140 Safari/537.36 Edge/17.17134
accept: application/json
Accept-Language: en-US,en;q=0.7,ko;q=0.3
Accept-Encoding: gzip, deflate
Content-Length: 0
Host: httpbin.org
Connection: Keep-Alive
Pragma: no-cache
Cookie: _gauges_unique_hour=1; _gauges_unique_month=1; _gauges_unique_day=1; _gauges_unique=1; _gauges_unique_year=1

";

            result = SendHttpBinRequest(httpRawData);

            return result;
        }

        public string RequestHttpBinPostMethod()
        {
            string result = null;
            string httpRawData = @"POST http://httpbin.org/post HTTP/1.1
Origin: http://httpbin.org
Referer: http://httpbin.org/
User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.140 Safari/537.36 Edge/17.17134
accept: application/json
Accept-Language: en-US,en;q=0.7,ko;q=0.3
Accept-Encoding: gzip, deflate
Content-Length: 0
Host: httpbin.org
Connection: Keep-Alive
Pragma: no-cache
Cookie: _gauges_unique_hour=1; _gauges_unique_month=1; _gauges_unique_day=1; _gauges_unique=1; _gauges_unique_year=1

";

            result = SendHttpBinRequest(httpRawData);

            return result;
        }

        public string RequestHttpBinPutMethod()
        {
            string result = null;
            string httpRawData = @"PUT http://httpbin.org/put HTTP/1.1
Origin: http://httpbin.org
Referer: http://httpbin.org/
User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.140 Safari/537.36 Edge/17.17134
accept: application/json
Accept-Language: en-US,en;q=0.7,ko;q=0.3
Accept-Encoding: gzip, deflate
Content-Length: 0
Host: httpbin.org
Connection: Keep-Alive
Pragma: no-cache
Cookie: _gauges_unique_hour=1; _gauges_unique_month=1; _gauges_unique_day=1; _gauges_unique=1; _gauges_unique_year=1

";

            result = SendHttpBinRequest(httpRawData);

            return result;
        }

        private string SendHttpBinRequest(string httpRawData)
        {
            int port = 80;
            string hostName = "httpbin.org";

            return SendHttpRequest(port, hostName, httpRawData);
        }

        private string SendHttpRequest(int port, string hostName, string httpRawData)
        {
            string result = null;

            using (var sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                IPHostEntry hostEntry = Dns.GetHostEntry(hostName);
                IPAddress ip = hostEntry.AddressList[0];

                var httpEndPoint = new IPEndPoint(ip, port);
                sock.Connect(httpEndPoint);

                // Send
                var sendBuff = Encoding.ASCII.GetBytes(httpRawData);
                sock.Send(sendBuff, SocketFlags.None);

                // Receive
                byte[] recvBuff = new byte[sock.ReceiveBufferSize];
                int nCount = sock.Receive(recvBuff);
                result = Encoding.ASCII.GetString(recvBuff, 0, nCount);
            }

            return result;
        }
    }
}
