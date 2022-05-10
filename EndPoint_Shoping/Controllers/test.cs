using Microsoft.AspNetCore.Mvc;
using Shoping.Application.Services.Repositories.IRepository;
using Shoping.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint_Shoping.Controllers
{
    public class test : Controller
    {
        private readonly IUserRepository _userRepository;
        public test(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult Index(string name, string email, string phone, string password)
        {
            User p = new User()
            {
                Name = name,
                User_Email = email,
                Role_Id = 1,
                User_Password = password,
                User_Phone = phone,
                User_Address = "",
                };
            _userRepository.InsertUser(p);
            _userRepository.Save();
            return View("true");
        }
    }
}
