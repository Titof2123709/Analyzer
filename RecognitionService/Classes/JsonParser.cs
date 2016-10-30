using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace RecognitionService.Classes
{
    public static class JsonParser
    {
        public static Dictionary<string, List<byte[,]>> GetInfoFromJson(string path = "")
        {
            try
            {
                var pathToJson = path != "" ? path : Environment.CurrentDirectory + "\\recognition.json";
                using (var r = new StreamReader(pathToJson))
                {
                    string json = r.ReadToEnd();
                    return JsonConvert.DeserializeObject<Dictionary<string, List<byte[,]>>>(json);
                }
            }
            catch (Exception)
            {
                throw new ApplicationException("Json module exeption was occured");
            }
        }
    }
}
