using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface IJsonHandler
    {
        OFXEntity GetInstance(string json);
        string Serialize(OFXEntity obj);
        void SaveData(string path, string fileContent);
        string ReadFile(string path);
    }
}
