using System.Drawing;
using System.Threading.Tasks;

namespace RecognitionService.Interfaces
{
    interface IRecognition
    {
        Task<int> ProcessedImages(Bitmap mathExample, Bitmap[] answers);
    }
}
