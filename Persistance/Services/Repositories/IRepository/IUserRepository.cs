using Shoping.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoping.Application.Services.Repositories.IRepository
{
    public interface IUserRepository
    {
        public void DelitUser(User user);
        public void DelitUserById(int userId);
        public User Get_UserById(int userid);
        public List<User> Get_AllUsers();
        public void InsertUser(User user);
        public bool EmailCheck(string email);
        public User UserCheck(string email, string password);
        public void Save();
        public void UpdateUser(User user);
    }
}
