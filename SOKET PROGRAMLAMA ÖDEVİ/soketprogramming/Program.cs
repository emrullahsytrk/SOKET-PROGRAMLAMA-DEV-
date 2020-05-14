﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace soketprogramming
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                s.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 600));
                s.Listen(9);
                Socket client = s.Accept();
                NetworkStream ns = new NetworkStream(client);
                StreamReader sr = new StreamReader(ns);
                Console.WriteLine(sr.ReadToEnd());
                sr.Close();
                ns.Close();
                s.Shutdown(SocketShutdown.Receive);
                client.Shutdown(SocketShutdown.Receive);
            }
            catch (SocketException exc)
            {
                Console.WriteLine("HATA OLUŞTU");
            }
            Console.Read();
        }
    }
}
