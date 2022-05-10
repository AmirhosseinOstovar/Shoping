using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Shoping.Application.Services.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EndPoint_Shoping.Controllers
{
    public class SingIn : Controller
    {
        private readonly IUserRepository _userRepository;
        public SingIn(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult Index()

        {
            return View();
        }
        public IActionResult LogIn(string email, string password)
        {
           
            var check = _userRepository.UserCheck(email, password);
            if (email != null && password != null && check!=null)
            {
                List<Claim> claims = new List<Claim>()
                {
                   

                    new Claim(ClaimTypes.NameIdentifier,check.Id.ToString()),
                    new Claim(ClaimTypes.Name,check.Name),
                    new Claim(ClaimTypes.Email,check.User_Email),
                    new Claim(ClaimTypes.Role,check.Role_Id.ToString())




                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimPrincipal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.Now.AddDays(5),
                };
                HttpContext.SignInAsync(claimPrincipal,properties);
                 
                return Redirect("~/Home");
            }
            else
            {
                return Redirect("~/SingIn");
            }
        }
        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }
    }
}
