using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HandWritingRecognitionServer
{
    class Server
    {
        public static Hashtable AllClients = new Hashtable();
        // information about the client
        public static TcpClient _client;
        private string _clientIP;
        private string _ClientNick;
        private bool got_Public_key = false;
        RSA rsa;
        // used for sending and reciving data
        private byte[] data;

        bool connected;
        string messageReceived = "";
        bool pictureIsSent = false;

        public Server()
        {

        }
        //public void main()
        //{
        //    IPAddress localAdd = IPAddress.Parse(SERVER_IP);
        //    TcpListener listener = new TcpListener(localAdd, PORT_NO);
        //    //---listen at the specified IP and port no.---
        //    Console.WriteLine("Listening...");
        //    listener.Start();

        //    while (true)
        //    {
        //        //---incoming client connected---//with every client
        //        TcpClient client = listener.AcceptTcpClient();
        //        Message_Org ClientH = new Message_Org(client);
        //        ListmsgO.Add(ClientH);
        //        ClientH.initialKeys();
        //        Console.WriteLine("connected, number of connections: " + _threads.Count());
        //        try
        //        {
        //            _threads.Add(new Thread(() => ClientHandle(ClientH)));
        //            _threads.Last().Start();
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e.Message);
        //        }
        //    }
        //    listener.Stop();
        //    Console.ReadLine();

        //}
    }
}
