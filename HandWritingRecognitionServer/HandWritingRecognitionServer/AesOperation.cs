using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace HandWritingRecognitionServer
{
    public static class AesOperation
    {
        public static byte[] DecryptPicture(byte[] bytesToDecrypt, string key)
        {
            byte[] iv = new byte[16];

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                using (MemoryStream mstream = new MemoryStream())
                using (AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider())
                using (CryptoStream cryptoStream = new CryptoStream(mstream, aesProvider.CreateDecryptor(aes.Key, aes.IV), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(bytesToDecrypt, 0, bytesToDecrypt.Length);
                    return mstream.ToArray();
                }

            }

        }

    }
}
