using HandWritingRecognitionServer.Data;
using System;


namespace HandWritingRecognitionServer
{
    public static class ProtocolManager
    {
        public static void ReadProtocol(string messageFromClient, PaintClient pc)
        /*
             Gets the message that was transferred from client and splits it to get valuable info
            Arguments:
                messageFromServer (string) - exact string that was sent by the client
                pc (PaintClient) - represents the current client object and used for transaction
             Return:
                void
        */
        {
            string[] str = messageFromClient.Split('#'); //splits the string into an array: num 1st, info 2nd...
            int num = int.Parse(str[0]); //getting the number which states about the content of the msg
            try
            {
                switch (num)
                {
                    case PaintClientProtocolType.SendDetails: //In case deails were sent
                        DataBaseManager.IsUserExists(str[1], str[2], pc); //checks username and email
                        break;

                    case PaintClientProtocolType.SendPublicKey: //In case public key was received
                        Console.WriteLine("public key was recieved");
                        pc.rsa.setOtherPublicKey(str[1]); //get other public key
                        pc.SendPublicKey(pc.rsa.GetPublicKey(), PaintClientProtocolType.SendPublicKey);
                        pc.got_Public_key = true;
                        break;

                    case PaintClientProtocolType.SendMessage:
                        //Broadcast(_ClientNick + "> " + str[1]);
                        break;

                    case PaintClientProtocolType.SendPicture: //In case picture Is about to be sent
                        pc.pictureIsSent = true;
                        break;

                    case PaintClientProtocolType.Register: //In case client sends username
                        DataBaseManager.AddUser(str[1], str[2], str[3], pc); //1 - username, 2 - password 3 -email
                        break;

                    case PaintClientProtocolType.SendPassword: //In case client sends password
                        DataBaseManager.ChangePassword(str[1], str[2], pc); //1 - password, 2 - email
                        break;

                    case PaintClientProtocolType.SendEmail: //In case client sends Email
                        DataBaseManager.CheckEmail(str[1], pc); //1 - email
                        break;

                    default:

                        break;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //used to add connect between strings
        public static string CreateProtocol(string msg, int type)
        /*
             combines message with type to one string by protocol
            Arguments:
                msg (string) - message
                type (int) - type of message
             Return:
                string
        */
        {
            return type + "#" + msg;
        }

    }
}
