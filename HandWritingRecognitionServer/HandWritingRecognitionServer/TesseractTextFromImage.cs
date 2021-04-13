using Patagames.Ocr;
using Patagames.Ocr.Enums;
using System.Drawing;

namespace HandWritingRecognitionServer
{
    static class TesseractTextFromImage
    {
        public static string ConvertImageToText(byte[] bytes)
        {

            using (var api = OcrApi.Create())
            {
                api.Init(Languages.English);
                string plainText = api.GetTextFromImage(ToImage(bytes));

                return plainText;
            }
        }
        private static Bitmap ToImage(byte[] imageData)
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
