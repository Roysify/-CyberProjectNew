using HandWritingRecognitionServer.Data;
using System;


namespace HandWritingRecognitionServer
{
    public static class ProtocolManager
    {
        //managing the agreed language between the client and the server
        public static void ReadProtocol(string msg, PaintClient pc)
        {
            string[] str = msg.Split('#'); //splits the string into an array: num 1st, info 2nd
            int num = int.Parse(str[0]); //getting the number which states about the content of the msg
            try
            {
                switch (num)
                {
                    case PaintClientProtocolType.SendDetails: //In case deails were sent
                        DataBaseManager.IsUserExists(str[1], str[2], pc); //checks username and email
                        break;

                    case PaintClientProtocolType.OkValidPasswordAndUsername: //In case deails were sent
                        //connected = true; //user logged in
                        break;

                    case PaintClientProtocolType.SendPublicKey: //In case a public key was received
                        Console.WriteLine("public key was recieved");
                        pc.rsa.setOtherPublicKey(str[1]); //get other public key
                        pc.SendPublicKey(pc.rsa.GetPublicKey(), PaintClientProtocolType.SendPublicKey);
                        pc.got_Public_key = true;
                        break;
                    case PaintClientProtocolType.SendMessage:
                        //Broadcast(_ClientNick + "> " + str[1]);
                        break;
                    case PaintClientProtocolType.SendPicture: //In picture Is about to be sent
                        pc.pictureIsSent = true;
                        break;
                    case PaintClientProtocolType.SendUsername: //In client sends username
                        if (DataBaseManager.IsUsernameExists(str[1], pc))
                        {
                            DataBaseManager.AddUser(str[1], str[2], pc); //1 - username, 2 - password
                        }
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

        public static string CreateProtocol(string msg, int type)
        {
            return type + "#" + msg; //adds the protocl type to the msg and divides with #
        }

    }
}
