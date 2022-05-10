﻿namespace Shoping.Domain.Entities.User
{
    public class UserInRole
    {
        public long  Id { get; set; }
        public virtual User User { get; set; }
        public long UserId { get; set; }
        public long RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
