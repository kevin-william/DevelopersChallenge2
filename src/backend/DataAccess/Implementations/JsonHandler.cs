using Constants;
using DataAccess.Interfaces;
using Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace DataAccess.Implementations
{
    public class JsonHandler : IJsonHandler
    {

        public OFXEntity GetInstance(string json)
        {
            return JsonConvert.DeserializeObject<OFXEntity>(json);
        }

        public string Serialize(OFXEntity obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public void SaveData(string path, string fileContent)
        {
            File.WriteAllText(path, fileContent);
        }

        public string ReadFile(string path)
        {
            if (File.Exists(path) && isPathValid(path))
            {
                return File.ReadAllText(path);
            }
            return string.Empty;
        }

        private bool isPathValid(string path)
        {
            return Regex.IsMatch(path, RegexConstants.JsonFilePattern);
        }
    }
}
