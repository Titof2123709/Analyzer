using System.Drawing;

namespace RecognitionService.Interfaces
{
    interface IRecognition
    {
        int ProcessedImages(Bitmap mathExample, Bitmap[] answers);
    }
}
