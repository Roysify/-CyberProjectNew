using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace HandWritingRecognitionServer
{
    public static class AesOperation
    {
        public static byte[] DecryptPicture(byte[] bytesToDecrypt, string key)
        /*
             decrypts picture bytes using a known to client key
            Arguments:
                bytesToEncrypt (byte[]) - picture bytes
                key (string) - decryption key
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

                using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                {
                    using (var ms = new MemoryStream())
                    using (var cryptoStream = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(bytesToDecrypt, 0, bytesToDecrypt.Length);
                        cryptoStream.FlushFinalBlock();

                        return ms.ToArray();
                    }
                }
            }
        }
    }
}
