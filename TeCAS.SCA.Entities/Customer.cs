using System.Collections.Generic;
using static TeCAS.SCA.Entities.Enumerations.EnumerationLists;

namespace TeCAS.SCA.Entities
{
    public class Customer : BaseEntity
    {
        public string FullName { get; set; }
        public string INE { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public Status Status { get; set; }

        public List<Account> Accounts { get; set; }
    }
}
