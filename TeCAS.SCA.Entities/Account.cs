using System;
using System.Collections.Generic;
using static TeCAS.SCA.Entities.Enumerations.EnumerationLists;

namespace TeCAS.SCA.Entities
{
    public class Account : BaseEntity
    {
        public string NoAccount { get; set; }
        public TypeAccount TypeAccount { get; set; }
        public Guid CustomerId { get; set; }

        public List<Transaction> Transactions { get; set; }
        public Customer Customer { get; set; }
    }
}
