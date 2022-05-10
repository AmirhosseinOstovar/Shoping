using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoping.Domain.Entities.User
{
    public class User
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string User_Phone { get; set; }
        public string User_Email { get; set; }
        public string User_Password { get; set; }
        public string User_Address { get; set; }
        public int Role_Id { get; set; }
        public ICollection<UserInRole> userInRoles { get; set; }

    }
}
