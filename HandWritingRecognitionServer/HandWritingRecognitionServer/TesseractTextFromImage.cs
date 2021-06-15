using Patagames.Ocr;
using Patagames.Ocr.Enums;
using System.Drawing;

namespace HandWritingRecognitionServer
{
    static class TesseractTextFromImage
    {
        public static string ConvertImageToText(byte[] bytes)
        /*
             converts image to text
            Arguments:
                bytes (bytes[]) - picture bytes
             Return:
                result (string)
        */
        {
            try
            {
                using (var api = OcrApi.Create())
                {
                    api.Init(Languages.English);
                    string plainText = api.GetTextFromImage(ToImage(bytes));

                    return plainText;
                }

            }
            catch (System.Exception)
            {
                return "I couldn't catch that.";
            }
        }
        private static Bitmap ToImage(byte[] imageData)
        /*
             converts byte[] to bitmap image
            Arguments:
                imageData (bytes[]) - picture bytes
             Return:
                image (bitmap)
        */
        {
            Bitmap bmp;
            using (var ms = new System.IO.MemoryStream(imageData))
            {
                bmp = new Bitmap(ms);
            }
            return bmp;
        }

    }
}
