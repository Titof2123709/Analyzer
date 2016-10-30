using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using RecognitionService.Interfaces;

namespace RecognitionService.Classes
{
    public class RService : IRecognition
    {
        private const int Width = 50;
        private const int Height = 60;
        private const int DeltaX = 30;
        public async Task<int> ProcessedImages(Bitmap mathExample, Bitmap[] answers)
        {
            try
            {
                var numbers = new List<int>();
                var dict = JsonParser.GetInfoFromJson();
                foreach (Bitmap item in answers)
                {
                    var key = await RecognizeIntFromBmp(item, dict);
                    numbers.Add(key);
                }
                int answer = await ProcessedExampleImage(mathExample, dict);
                return numbers.IndexOf(answer);
            }
            catch (ApplicationException)
            {
                //Log it
                throw new ApplicationException("Json file was not upload");
            }
            catch (Exception)
            {
                //Log it
                throw new ApplicationException("Recognize is failed");
            }
        }

        private Task<int> RecognizeIntFromBmp(Bitmap answer, Dictionary<string, List<byte[,]>> dict)
        {
            return Task.Run(() =>
            {
                var answerByteArray = new byte[Width, Height];
                for (int i = 0; i < Width; i++)
                {
                    for (int j = 0; j < Height; j++)
                    {
                        answerByteArray[i, j] = answer.GetPixel(i, j).R;
                    }
                }
                return RecognizeIntFromBmp(answerByteArray, dict);
            });
        }

        private Task<int> RecognizeIntFromBmp(byte[,] answer, Dictionary<string, List<byte[,]>> dict)
        {
            return Task.Run(() =>
            {
                int number = 0;
                double minDist = double.MaxValue;
                foreach (var item in dict)
                {
                    var distMin = CalcMinDistance(answer, item.Value);
                    if (minDist > distMin)
                    {
                        minDist = distMin;
                        number = int.Parse(item.Key);
                    }
                }
                return number;
            });
        }

        private double CalcMinDistance(byte[,] answer, List<byte[,]> list)
        {
            return list.Select(c => CalcDistance(answer, c)).Concat(new[] { double.MaxValue }).Min();
        }

        private double CalcDistance(byte[,] answer, byte[,] byted)
        {
            double distance = 0;
            for (int i = 0; i < Width; ++i)
            {
                for (int j = 0; j < Height; ++j)
                {
                    distance += Math.Pow(answer[i, j] - byted[i, j], 2);
                }
            }
            return Math.Pow(distance, 0.5);
        }

        private async Task<int> ProcessedExampleImage(Bitmap example, Dictionary<string, List<byte[,]>> dict)
        {
            var defColor = example.GetPixel(0, 0);
            var numberFirst = new Bitmap(example, Width, Height);
            for (int i = Width; i < Width + DeltaX; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    example.SetPixel(i, j, defColor);
                }
            }
            var firstNumber = await RecognizeIntFromBmp(numberFirst, dict);
            var secondByted = new byte[Width, Height];
            int k = 0;
            for (int i = Width + DeltaX - 10; i < Width + DeltaX - 10 + Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    secondByted[k,j] = example.GetPixel(i, j).R;
                }
                k++;
            }
            var secondNumber = await RecognizeIntFromBmp(secondByted, dict);
            return firstNumber + secondNumber;
        } 
    }
}
