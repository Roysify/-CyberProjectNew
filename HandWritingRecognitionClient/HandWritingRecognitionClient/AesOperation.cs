using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace HandWritingRecognitionClient
{
    public static class AesOperation
    {
        public static byte[] EncryptPicture(byte[] bytesToEncrypt, string key)
        /*
             encrypts picture bytes using a known to server key
            Arguments:
                bytesToEncrypt (byte[]) - picture bytes
                key (string) - encryption key
             Return:
                void
        */
        {
            byte[] iv = new byte[16];

            using (Aes aes = Aes.Create())
            {
                aes.Padding = PaddingMode.Zeros;
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(bytesToEncrypt, 0, bytesToEncrypt.Length);
                        cryptoStream.FlushFinalBlock();

                        return memoryStream.ToArray();
                    }
                }
            }
        }
    }
}
