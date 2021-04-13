using System;
using System.Security.Cryptography;
using System.Text;


namespace HandWritingRecognitionClient
{
    public class RSA
    {
        private static string _privateKey;
        private static string my_publicKey;
        private static string other_publicKey;
        private static UnicodeEncoding _encoder = new UnicodeEncoding();
        private static RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

        public RSA()
        {
            other_publicKey = "";
            _privateKey = rsa.ToXmlString(true);
            my_publicKey = rsa.ToXmlString(false);

        }
        public string Decrypt(string data)
        {
            var rsa = new RSACryptoServiceProvider();
            var dataArray = data.Split(new char[] { ',' });
            byte[] dataByte = new byte[dataArray.Length];
            for (int i = 0; i < dataArray.Length; i++)
            {
                dataByte[i] = Convert.ToByte(dataArray[i]);
            }

            rsa.FromXmlString(_privateKey);
            var decryptedByte = rsa.Decrypt(dataByte, false);
            return _encoder.GetString(decryptedByte);
        }
        public string Encrypt(string data)
        {
            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(other_publicKey);
            var dataToEncrypt = _encoder.GetBytes(data);
            var encryptedByteArray = rsa.Encrypt(dataToEncrypt, false);
            var length = encryptedByteArray.Length;
            var item = 0;
            var sb = new StringBuilder();
            foreach (var x in encryptedByteArray)
            {
                item++;
                sb.Append(x);

                if (item < length)
                    sb.Append(",");
            }

            return sb.ToString();
        }
        public string Encrypt(byte[] data)
        {
            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(other_publicKey);
            //var dataToEncrypt = _encoder
            var encryptedByteArray = rsa.Encrypt(data, false);
            var length = encryptedByteArray.Length;
            var item = 0;
            var sb = new StringBuilder();
            foreach (var x in encryptedByteArray)
            {
                item++;
                sb.Append(x);

                if (item < length)
                    sb.Append(",");
            }

            return sb.ToString();
        }
        public string GetPublicKey()
        {
            return my_publicKey;
        }
        public void setOtherPublicKey(string key)
        {
            other_publicKey = key;
        }
    }
}
