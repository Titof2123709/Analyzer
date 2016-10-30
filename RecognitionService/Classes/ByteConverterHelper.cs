using System.Drawing;

namespace RecognitionService.Classes
{
    public static class ByteConverterHelper
    {
        public static byte[,] GenerateByteArrayFromBitmap(Bitmap png)
        {
            byte[,] arrayBytes = new byte[png.Width, png.Height];
            for (int i = 0; i < png.Width; ++i)
            {
                for (int j = 0; j < png.Height; ++j)
                {
                    arrayBytes[i, j] = png.GetPixel(i, j).R;
                }
            }
            return arrayBytes;
        }
    }
}
