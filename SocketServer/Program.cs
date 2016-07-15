﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocketServer
{
    using System.Net;

    class Program
    {
        static void Main(string[] args)
        {
            var server=new Server(10,1024);
            server.Init();
            server.Start(new IPEndPoint(IPAddress.Any, 7075));
            Console.ReadLine();
        }
    }
}
