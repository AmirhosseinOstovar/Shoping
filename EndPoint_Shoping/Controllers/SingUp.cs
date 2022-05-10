using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Shoping.Application.Services.Repositories.IRepository;
using Shoping.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EndPoint_Shoping.Controllers
{
    public class SingUp : Controller
    {
        private readonly IUserRepository _IUserrepository;

        public SingUp(IUserRepository userRepository)
        {
            _IUserrepository = userRepository;
        }
        public IActionResult Index()
        {

            return View();
        }
        // [HttpPost]
        public IActionResult Creat(string name, string email, string password, string phone, string address)
        {
             var check = _IUserrepository.EmailCheck(email);
           // var checku = _IUserrepository.UserCheck(email, password);

            if (email != null && password != null &&  check == false)
            {
                User u = new User()
                {
                    Name = name,
                    User_Address = address,
                    User_Email = email,
                    User_Phone = phone,
                    User_Password = password,
                    Role_Id = 2,
                };
                _IUserrepository.InsertUser(u);
                _IUserrepository.Save();


                List<Claim> claims = new List<Claim>()
                {


                    new Claim(ClaimTypes.NameIdentifier,u.Id.ToString()),
                    new Claim(ClaimTypes.Name,u.Name),
                    new Claim(ClaimTypes.Email,u.User_Email),
                    new Claim(ClaimTypes.Role,u.Role_Id.ToString())




                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimPrincipal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.Now.AddDays(5),
                };
                HttpContext.SignInAsync(claimPrincipal, properties);

                return Redirect("~/Home");


            }
            else
            {
                return Redirect("~/Singup");
            }
        }




    }
}
