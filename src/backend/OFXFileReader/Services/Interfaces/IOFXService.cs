using Entities;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace OFXFileReader.Services.Interfaces
{
    public interface IOFXService
    {

        OFXEntity Get();

        Task SaveOFXTransactions(IEnumerable<Stream> fileListAsStream);

    }
}
