using static TeCAS.SCA.Entities.Enumerations.EnumerationLists;

namespace TeCAS.SCA.Entities
{
    public class User : BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Status Status { get; set; }
        public Role Role { get; set; }
    }
}
