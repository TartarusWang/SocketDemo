/*****************************************************************************************
 * 创建者：  王福春
 * 项目名程：SocketServer
 * 文件描述：
 * 创建时间：2016-07-07 15:46
 *****************************************************************************************/
namespace SocketServer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;

    public class Server
    {
        public void Listen(IPEndPoint localPoint)
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(localPoint);
            socket.Listen(100);
            var socketThread = new Thread(OnSocketAccept) { IsBackground = true };
            socketThread.Start(socket);
            Console.WriteLine("服务准备就绪");
            Console.ReadKey();
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
            Console.ReadLine();
        }

        private void OnSocketAccept(object obj)
        {
            var socket = obj as Socket;
            if (null == socket) return;
            do
            {
                var client = socket.Accept();
                ThreadPool.QueueUserWorkItem(this.ReceiveData, client);
                this.ReceiveData(client);
            } while (true);
        }

        private void ReceiveData(object obj)
        {
            var client = obj as Socket;
            do
            {
                var bytes = new byte[1024 * 4];
                try
                {
                    int len = client.Receive(bytes);
                    if (len > 0)
                    {
                        Console.WriteLine(Encoding.UTF8.GetString(bytes.Take(len).ToArray()));

                        //client.Shutdown(SocketShutdown.Both);
                    }
                    else
                    {
                        //client.Shutdown(SocketShutdown.Both);
                        client.Close();
                    }

                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    client.Close();
                    break;
                }
            } while (true);
        }
    }
}