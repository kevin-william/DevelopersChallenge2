using Entities.Enums;
using System;

namespace Entities
{
    public class OFXTransaction
    {
        public OFXTransactionTypeEnum Type { get; set; }        
        public double Value { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }

    }
}
