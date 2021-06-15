using Patagames.Ocr;
using Patagames.Ocr.Enums;
using System.Drawing;

namespace HandWritingRecognitionServer
{
    static class TesseractTextFromImage
    {
        public static string ConvertImageToText(byte[] bytes)
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
        }// converts image to text
        private static Bitmap ToImage(byte[] imageData)
        {
            Bitmap bmp;
            using (var ms = new System.IO.MemoryStream(imageData))
            {
                bmp = new Bitmap(ms);
            }
            return bmp;
        } //converts byte[] to bitmap image

    }
}
