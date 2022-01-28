using System;
using static TeCAS.SCA.Entities.Enumerations.EnumerationLists;

namespace TeCAS.SCA.Entities
{
    public class Transaction : BaseEntity
    {
        public Guid AccountId { get; set; }
        public decimal CurrentBalance { get; set; }
        public decimal MovementAmount { get; set; }

        public TypeTransaction TypeTransaction { get; set; }
        public Account Account { get; set; }
    }
}
