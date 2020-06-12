using System.Collections.Generic;

namespace Entities.Helpers.Interfaces
{
    public interface IOFXTransactionHelper
    {

        IEnumerable<OFXTransaction> Merge(IEnumerable<OFXTransaction> transactions, IEnumerable<OFXTransaction> transactionsToMerge);
        IEnumerable<OFXTransaction> Distinct(IEnumerable<OFXTransaction> transaction);
    }
}
