using System;

namespace TeCAS.SCA.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public string CreateById { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
