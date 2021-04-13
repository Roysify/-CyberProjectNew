using HandWritingRecognitionServer.Data;
using System;


namespace HandWritingRecognitionServer
{
    public static class ProtocolManager
    {

        public static void ReadProtocol(string msg, PaintClient pc)
        {
            string[] str = msg.Split('#'); //num 1st, info 2nd
            int num = int.Parse(str[0]);
            try
            {
                switch (num)
                {
                    case PaintClientProtocolType.SendDetails:
                        DataBaseManager.IsUserExists(str[1], str[2], pc); //checks username and email
                        break;

                    case PaintClientProtocolType.OkValidPasswordAndUsername:
                        //connected = true; //user logged in
                        break;

                    case PaintClientProtocolType.SendPublicKey:
                        Console.WriteLine("public key was recieved");
                        pc.rsa.setOtherPublicKey(str[1]); //get other public key
                        pc.SendPublicKey(pc.rsa.GetPublicKey(), PaintClientProtocolType.SendPublicKey);
                        pc.got_Public_key = true;
                        break;
                    case PaintClientProtocolType.SendMessage:
                        //Broadcast(_ClientNick + "> " + str[1]);
                        break;
                    case PaintClientProtocolType.SendPicture:
                        pc.pictureIsSent = true;
                        break;
                    case PaintClientProtocolType.SendUsername:
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
            return type + "#" + msg;
        }

    }
}
