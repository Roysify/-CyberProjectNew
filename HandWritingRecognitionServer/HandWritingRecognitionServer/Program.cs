using System;
using System.Net.Sockets;

namespace HandWritingRecognitionServer
{
    class Program
    {
        const int portNo = 500;
        private const string ipAddress = "127.0.0.1";

        static void Main(string[] args)
        {

            //creats listener based on local adress and port number
            System.Net.IPAddress localAdd = System.Net.IPAddress.Parse(ipAddress);
            TcpListener listener = new TcpListener(localAdd, portNo);
            Console.WriteLine("Listening to ip {0} port: {1}", ipAddress, portNo);

            // Start listen to incoming connection requests
            listener.Start();

            // infinite loop.
            while (true)
            {
                // AcceptTcpClient - Blocking call
                // Execute will not continue until a connection is established

                // We create an instance of paint Client so the server will be able to 
                // serve multiple clients at the same time.
               PaintClient user = new PaintClient(listener.AcceptTcpClient());

            }


        }
    }
}
