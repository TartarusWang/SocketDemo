using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SocketClient
{
    using System.Net;
    using System.Net.Sockets;
    using System.Runtime.InteropServices;

    class Program
    {
        static void Main(string[] args)
        {
           
            var client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //client.Connect(IPAddress.Parse("127.0.0.1"), 7075);
            client.Connect(IPAddress.Parse("183.136.162.82"), 7075);
            //uint dummy = 0;
            //var inOptionValues = new byte[Marshal.SizeOf(dummy) * 3];
            //BitConverter.GetBytes((uint)1).CopyTo(inOptionValues, 0);
            //BitConverter.GetBytes((uint)5000).CopyTo(inOptionValues, Marshal.SizeOf(dummy));
            //BitConverter.GetBytes((uint)5000).CopyTo(inOptionValues, Marshal.SizeOf(dummy) * 2);
            //client.IOControl(IOControlCode.KeepAliveValues, inOptionValues, null);
            var msg = "send a test package to test socket!";
            var msgBytes = Encoding.UTF8.GetBytes(msg);
            Console.WriteLine(msgBytes.Length);
            int t = client.Send(msgBytes);
            var bytes = new byte[4096];
            var len = client.Receive(bytes);
            Console.WriteLine(Encoding.UTF8.GetString(bytes, 0, len));
            Thread.Sleep(10000);
            //client.Close();
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
            tcpClient.Connect(new IPEndPoint(IPAddress.Parse("183.136.162.82"), 7075));
            var bytes = Encoding.UTF8.GetBytes("send a test package!");
            Console.WriteLine(bytes.Length);
            tcpClient.Client.Send(bytes);
            Console.ReadKey();
        }
    }
}
