using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SocketClient
{
    using System.Net;
    using System.Net.Sockets;

    class Program
    {
        static void Main(string[] args)
        {
           
            var client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //client.Connect(IPAddress.Parse("127.0.0.1"), 7075);
            client.Connect(IPAddress.Parse("183.136.162.82"), 7075);
            var msg = "send a test package!";
            var msgBytes = Encoding.UTF8.GetBytes(msg);
            int t = client.Send(msgBytes);
            var bytes = new byte[4096];
            //var len = client.Receive(bytes);
            Thread.Sleep(10000);
            client.Close();
            //do
            //{
            //    try
            //    {
            //        var len = client.Receive(bytes);
            //        if (len <= 0)
            //        {
            //            //client.Shutdown(SocketShutdown.Both);
            //            client.Close();
            //            break;
            //        }
            //    }
            //    catch (System.Exception ex)
            //    {
            //        client.Shutdown(SocketShutdown.Both);
            //        client.Close();
            //        break;
            //    }


            //} while (true);


            Console.ReadLine();
        }

        static void CreateTcpClient()
        {
            var tcpClient = new TcpClient(AddressFamily.InterNetwork);
            tcpClient.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1818));
        }
    }
}
