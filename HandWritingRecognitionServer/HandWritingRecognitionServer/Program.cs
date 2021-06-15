using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace HandWritingRecognitionServer
{
    class Program
    {
        private const int portNo = 500; //port number used for transaction
        private static string ipAddress = "";//ip address 

        static void Main(string[] args)
        {
            //creating a new log document every new server session
            string workingDirectory = Environment.CurrentDirectory;//gets the current path
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName; //gets the correct path for log location
            string logPath = projectDirectory + "/log";//adds log name
            File.AppendAllText(logPath, "log:" + Environment.NewLine);//creates log file

            //creats listener based on local address and port number
            ipAddress = GetLocalIPAddress();
            System.Net.IPAddress localAdd = System.Net.IPAddress.Parse(ipAddress);
            TcpListener listener = new TcpListener(localAdd, portNo);
            Console.WriteLine("Listening to ip {0} port: {1}", ipAddress, portNo);
             
            Console.WriteLine();
            // Start listen to incoming connection requests
            listener.Start();

            // infinite loop.
            while (true)
            {
                // AcceptTcpClient - Blocking call
                // Execute will not continue until a connection is established

                // We create an instance of paint Client so the server will be able to 
                // serve multiple clients at the same time.
               PaintClient user = new PaintClient(listener.AcceptTcpClient(),logPath);

            }


        }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
