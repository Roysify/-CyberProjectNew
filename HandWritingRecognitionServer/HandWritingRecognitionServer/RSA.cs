using System;
using System.Security.Cryptography;
using System.Text;

namespace HandWritingRecognitionServer
{
    public class RSA
    {
        private static string _privateKey; //The private key used for decryption.
        private static string my_publicKey; //The public key used for the other side's encryption.
        private static string other_publicKey; //The other side's public key used for encryption.
        private static UnicodeEncoding _encoder; //The encoder used for encoding bytes to string.
        private static RSACryptoServiceProvider rsa; //The object provides the public and private key using the RSA algorithm.

        public RSA()
        {
            //The constructive function builds an object used for security measures in the project.
            _encoder = new UnicodeEncoding();
            rsa = new RSACryptoServiceProvider();
            other_publicKey = "";
            _privateKey = rsa.ToXmlString(true);
            my_publicKey = rsa.ToXmlString(false);

        }
        public string Decrypt(string data)
        {
            // Decrypts the string
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
            // encrypts the string
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
