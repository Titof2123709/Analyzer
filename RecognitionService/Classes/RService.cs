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
        public async Task<int> ProcessedImages(Bitmap mathExample, Bitmap[] answers)
        {
            try
            {
                int answer = 0;
                int[] numbers = new int[answers.Length];
                var dict = JsonParser.GetInfoFromJson();
                for (int i = 0; i < answers.Length; i++)
                {
                    numbers[i] = await RecognizeIntFromBmp(answers[i], dict);
                }
                answer = numbers[0];
                return answer;
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

        private static double CalcMinDistance(Bitmap answer, List<byte[,]> list)
        {
            return list.Select(c => CalcDistance(answer, c)).Concat(new[] { double.MaxValue }).Min();
        }

        private static double CalcDistance(Bitmap answer, byte[,] byted)
        {
            double distance = 0;
            for (int i = 0; i < answer.Width; ++i)
            {
                for (int j = 0; j < answer.Height; ++j)
                {
                    distance += Math.Pow(answer.GetPixel(i, j).R - byted[i, j], 2);
                }
            }
            return Math.Pow(distance, 0.5);
        }
    }
}
