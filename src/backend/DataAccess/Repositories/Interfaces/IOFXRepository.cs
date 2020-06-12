using Entities;
using System.Collections.Generic;

namespace DataAccess.Repositories.Interfaces
{
    public interface IOFXRepository
    {

        void Save(OFXEntity entity);

        OFXEntity Get();

    }
}
