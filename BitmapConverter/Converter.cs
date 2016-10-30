using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using RecognitionService.Classes;

namespace BitmapConverter
{
    public static class Converter
    {
        public static void ConvertBitmapToByte(string path = "")
        {
            if (path.Equals(string.Empty))
            {
                var temp = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase))));
                path += $"{temp}\\BitmapConverter\\res\\";
                path = new Uri(path).LocalPath;
            }
            // dictonary for numbers byte array e.g. "1" - byteArray1[50,60], byteArray2[50,60] etc.
            var dict = new Dictionary<string, List<byte[,]>>();
            var directories = Directory.GetDirectories(path);
            foreach (var dir in directories)
            {
                string[] fileEntries = Directory.GetFiles(dir);
                var list = fileEntries.Select(fileName => new Bitmap(fileName)).Select(ByteConverterHelper.GenerateByteArrayFromBitmap).ToList();
                var number = dir.Substring(dir.Length - 1, 1);
                dict.Add(number, list);
            }
            string json = JsonConvert.SerializeObject(dict, Formatting.Indented);
            File.WriteAllText(path + "recognition.json", json);
        }
    }
}
