
using Shoping.Application.Services.Repositories.IRepository;
using Shoping.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Shoping.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace Shoping.Application.Services.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataBaseContext _dataBaseContext;
        public UserRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public void DelitUser(User user)
        {
            _dataBaseContext.Entry(user).State = EntityState.Deleted;

        }

        public void DelitUserById(int userId)
        {
            var u = Get_UserById(userId);
            DelitUser(u);

        }

        public bool EmailCheck(string email)
        {

            var p = _dataBaseContext.Users.Where(p => p.User_Email == email).SingleOrDefault();

            if (p == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<User> Get_AllUsers()
        {
            return _dataBaseContext.Users.ToList();
        }

        public User Get_UserById(int userid)
        {
            return _dataBaseContext.Users.Find(userid);
        }

        public void InsertUser(User user)
        {
            _dataBaseContext.Users.Add(user);
        }

        public void Save()
        {
            _dataBaseContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _dataBaseContext.Entry(user).State = EntityState.Modified;
        }

        public User UserCheck(string email, string password)
        {

            var p = _dataBaseContext.Users.Where(p => email == p.User_Email && password == p.User_Password).SingleOrDefault();
            if (p != null)
            {
                return p;
            }
            else
            {
                return null;
            }
        }
    }
}
