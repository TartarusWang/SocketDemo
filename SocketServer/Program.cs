using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocketServer
{
    using System.Net;
    using System.Net.Sockets;

    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.Listen(new IPEndPoint(IPAddress.Any, 7075));
        }

    }
}
