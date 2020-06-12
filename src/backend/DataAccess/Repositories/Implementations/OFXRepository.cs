using DataAccess.Interfaces;
using DataAccess.Repositories.Interfaces;
using Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace DataAccess.Repositories.Implementations
{
    public class OFXRepository : IOFXRepository
    {
        public OFXRepository(
            IJsonHandler jsonHandler,
            IConfiguration configuration)
        {
            JsonHandler = jsonHandler ??
                throw new ArgumentNullException(nameof(jsonHandler));
            Configuration = configuration ??
                throw new ArgumentNullException(nameof(configuration));
            JsonPath = Configuration.GetSection("JsonPath").Value;
        }

        private IJsonHandler JsonHandler { get; }
        private IConfiguration Configuration { get; }
        public string JsonPath { get; }

        public void Save(OFXEntity entity)
        {
            var entityAsJSON = JsonHandler.Serialize(entity);
            JsonHandler.SaveData(JsonPath, entityAsJSON);
        }

        public OFXEntity Get()
        {
            var fileAsJson = JsonHandler.ReadFile(JsonPath);
            return JsonHandler.GetInstance(fileAsJson);
        }
    }
}
