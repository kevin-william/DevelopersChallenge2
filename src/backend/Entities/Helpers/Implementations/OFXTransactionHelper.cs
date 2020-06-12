using Entities.Comparators;
using Entities.Helpers.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Entities.Helpers.Implementations
{
    public class OFXTransactionHelper : IOFXTransactionHelper
    {
        public IEnumerable<OFXTransaction> Merge(IEnumerable<OFXTransaction> transactions, IEnumerable<OFXTransaction> transactionsToMerge)
        {
            return transactions.Concat(transactionsToMerge).Distinct(new TransactionComparator());
        }

        public IEnumerable<OFXTransaction> Distinct(IEnumerable<OFXTransaction> transaction)
        {
            return transaction.Distinct(new TransactionComparator());
        }

    }
}
