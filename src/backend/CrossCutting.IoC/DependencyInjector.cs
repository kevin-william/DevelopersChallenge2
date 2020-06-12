using DataAccess.Implementations;
using DataAccess.Interfaces;
using DataAccess.Repositories.Implementations;
using DataAccess.Repositories.Interfaces;
using Entities.Helpers.Implementations;
using Entities.Helpers.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OFXFileReader.Business.Implementations;
using OFXFileReader.Business.Interfaces;
using OFXFileReader.Services.Implementations;
using OFXFileReader.Services.Interfaces;

namespace CrossCutting.IoC
{
    public class DependencyInjector
    {
        public static void RegisterServices(IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddScoped<IFileReader, FileReader>();
            services.AddScoped<IOFXTransactionHelper, OFXTransactionHelper>();
            services.AddScoped<IJsonHandler, JsonHandler>();
            services.AddScoped<IOFXService, OFXService>();
            services.AddScoped<IOFXRepository, OFXRepository>();
        }

    }
}
