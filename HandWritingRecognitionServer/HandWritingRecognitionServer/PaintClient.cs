using HandWritingRecognitionServer.Data;
using System;
using System.Collections;
using System.Net.Sockets;



namespace HandWritingRecognitionServer
{
    public class PaintClient
    {
        // Store list of all clients connecting to the server
        // the list is static so all memebers of the chat will be able to obtain list
        // of current connected client
        public static Hashtable AllClients = new Hashtable(); //all clients hashtable
        // information about the client
        private TcpClient _client;
        public RSA rsa;
        private string _clientIP;
        // used for sending and reciving data
        private byte[] data;

        bool connected;
        private string _ClientNick;

        public bool got_Public_key = false;
        string messageReceived = "";
        public bool pictureIsSent = false;

        public PaintClient(TcpClient client)
        {
            rsa = new RSA();
            _client = client;
            // get the ip address of the client to register him with our client list
            _clientIP = client.Client.RemoteEndPoint.ToString();

            // Add the new client to our clients collection
            AllClients.Add(_clientIP, this);

            // Read data from the client async
            data = new byte[_client.ReceiveBufferSize];

            // BeginRead will begin async read from the NetworkStream
            // This allows the server to remain responsive and continue accepting new connections from other clients
            // When reading complete control will be transfered to the ReviveMessage() function.
            _client.GetStream().BeginRead(data, 0, System.Convert.ToInt32(_client.ReceiveBufferSize), ReceiveMessage, null);
        }

        public void SendMessage(int type)
        {
            try
            {
                System.Net.Sockets.NetworkStream ns;

                // we use lock to present multiple threads from using the networkstream object
                // this is likely to occur when the server is connected to multiple clients all of 
                // them trying to access to the networkstram at the same time.
                lock (_client.GetStream())
                {
                    ns = _client.GetStream();
                }
                // Send data to the client
                byte[] bytesToSend = System.Text.Encoding.ASCII.GetBytes(rsa.Encrypt(type.ToString()));
                ns.Write(bytesToSend, 0, bytesToSend.Length);
                ns.Flush();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        } //sends message to client
        private void SendResult(string result)
        {
            try
            {
                System.Net.Sockets.NetworkStream ns;

                // we use lock to present multiple threads from using the networkstream object
                // this is likely to occur when the server is connected to multiple clients all of 
                // them trying to access to the networkstram at the same time.
                lock (_client.GetStream())
                {
                    ns = _client.GetStream();
                }
                // Send data to the client
                byte[] bytesToSend = System.Text.Encoding.ASCII.GetBytes(rsa.Encrypt(ProtocolManager.CreateProtocol(result, PaintClientProtocolType.result)));
                ns.Write(bytesToSend, 0, bytesToSend.Length);
                ns.Flush();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        } //sends text result to client

        public void SendPublicKey(string message, int type)
        {
            try
            {
                System.Net.Sockets.NetworkStream ns;

                // we use lock to present multiple threads from using the networkstream object
                // this is likely to occur when the server is connected to multiple clients all of 
                // them trying to access to the networkstram at the same time.
                lock (_client.GetStream())
                {
                    ns = _client.GetStream();
                }
                message = ProtocolManager.CreateProtocol(message, type);
                // Send data to the client
                byte[] bytesToSend = System.Text.Encoding.ASCII.GetBytes(message);
                ns.Write(bytesToSend, 0, bytesToSend.Length);
                ns.Flush();
                Console.WriteLine("servers public key was sent");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        } //sends public key to client

        public void ReceiveMessage(IAsyncResult ar)
        {
            int bytesRead;
            try
            {
                lock (_client.GetStream())
                {
                    // call EndRead to handle the end of an async read.
                    bytesRead = _client.GetStream().EndRead(ar);
                }

                //respond with the right action based on boolians
                MsgOrder(bytesRead);   

                lock (_client.GetStream())
                {
                    // continue reading form the client
                    _client.GetStream().BeginRead(data, 0, System.Convert.ToInt32(_client.ReceiveBufferSize), ReceiveMessage, null);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //AllClients.Remove(_clientIP);
            }
        } //receives messages from client

        private void MsgOrder(int bytesRead)
        {
            if (!got_Public_key)
            {
                messageReceived = System.Text.Encoding.ASCII.GetString(data, 0, bytesRead);
                // transfer msg string to protocol manager
                ProtocolManager.ReadProtocol(messageReceived, this);

            }
            else if (pictureIsSent)
            {
                pictureIsSent = false;
                SendResult(TesseractTextFromImage.ConvertImageToText(data));
            }
            else
            {
                messageReceived = rsa.Decrypt(System.Text.Encoding.ASCII.GetString(data, 0, bytesRead));
                Console.WriteLine(messageReceived);
                // transfer msg string to protocol manager
                ProtocolManager.ReadProtocol(messageReceived, this);
            }

        }

        //public void Broadcast(int msgType)
        //{
        //    Console.WriteLine(msgType);
        //    foreach (DictionaryEntry c in AllClients)
        //    {
        //        ((PaintClient)(c.Value)).SendMessage(send_message);
        //    }
        //}


        //public System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        //{
        //    MemoryStream ms = new MemoryStream(byteArrayIn);
        //    System.Drawing.Image returnImage = Image.FromStream(ms);
        //    return returnImage;
        //}
    }

}

