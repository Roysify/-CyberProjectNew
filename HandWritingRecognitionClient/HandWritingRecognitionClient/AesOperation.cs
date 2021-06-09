using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace HandWritingRecognitionClient
{
    public static class AesOperation
    {

        public static byte[] EncryptString(string key, byte[] pictursBytes)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(pictursBytes);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            //return Convert.ToBase64String(array);
            return array;
        }//just a sample

        public static string DecryptString(string key, string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }//sample

        public static byte[] EncryptPicture(byte[] bytesToEncrypt, string key)
        {
            byte[] iv = new byte[16];

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                using (MemoryStream mstream = new MemoryStream())
                using (AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider())
                using (CryptoStream cryptoStream = new CryptoStream(mstream, aesProvider.CreateEncryptor(aes.Key, aes.IV), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(bytesToEncrypt, 0, bytesToEncrypt.Length);
                    return mstream.ToArray();
                }

            }

        }//the one that used

    }
}
