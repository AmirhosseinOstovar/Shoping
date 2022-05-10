using System.Collections.Generic;

namespace Shoping.Domain.Entities.User
{
    public class Role
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserInRole>  userInRoles { get; set; }

    }
}
