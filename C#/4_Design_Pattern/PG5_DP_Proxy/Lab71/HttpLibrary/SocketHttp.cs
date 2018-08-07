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

        public string RequestHttpBinGetMethod()
        {
            int port = 80;
            string result = null;
            string hostName = "httpbin.org";
            string httpRawData = @"GET http://httpbin.org/get HTTP/1.1
Host: httpbin.org
Connection: keep-alive
Upgrade-Insecure-Requests: 1
User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.84 Safari/537.36
Accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8
Accept-Encoding: gzip, deflate
Accept-Language: en-US,en;q=0.9

";

            result = SendHttpRequest(port, hostName, httpRawData);


            return result;
        }

        /// <param name="httpRawData">HTTP header should end with double newline (\r\n\r\n)</param>
        public string SendHttpRequest(int port, string hostName, string httpRawData)
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
