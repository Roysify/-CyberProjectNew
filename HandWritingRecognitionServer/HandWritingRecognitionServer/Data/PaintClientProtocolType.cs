namespace HandWritingRecognitionServer.Data
{
    public class PaintClientProtocolType
    {
        //agreed consts serving as message types
        public const int ErvrorInvalidPasswordAndUsername = 0;
        public const int OkValidPasswordAndUsername = 1;
        public const int SendDetails = 2;
        public const int SendMessage = 3;
        public const int SendPublicKey = 4;
        public const int DetailsSent = 5;
        public const int SendPicture = 6;
        public const int Register = 7;
        public const int UsernameExists = 8;
        public const int UserAdded = 9;
        public const int Result = 10;
        public const int SendEmail = 11;
        public const int UsernameOrEmailUnavailable = 12;
        public const int SendPassword = 13;
        public const int PasswordChanged = 14;
        public const int EmailExists = 15;
        public const int EmailInvalid = 16;
        public const int CorrectEmailCode = 17;
        public const int IncorrectEmailCode = 18;


    }
}
