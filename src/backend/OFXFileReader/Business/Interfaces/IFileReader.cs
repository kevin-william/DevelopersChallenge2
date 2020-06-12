using Entities;
using System.IO;
using System.Threading.Tasks;

namespace OFXFileReader.Business.Interfaces
{
    public interface IFileReader
    {

        Task<OFXEntity> ReadFile(Stream stream);

    }
}
