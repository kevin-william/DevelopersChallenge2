using Entities.Enums;
using System.Collections.Generic;

namespace Entities
{
    public class OFXEntity
    {
        public OFXCurrenciesEnum Currency { get; set; }
        public IEnumerable<OFXTransaction> OFXTransactions { get; set; }
    }
}
