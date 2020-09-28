using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using TicketService.Models;

namespace TicketService.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager usermanager;

        public UserController(UserManager usermanager)
        {
            this.usermanager = usermanager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (!usermanager.ValidatePassword(model.UserName, model.Password))
                {
                    ModelState.AddModelError(nameof(model.Password), "wrong password");
                    return View();
                }

                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, model.UserName),
                    new Claim(ClaimTypes.Role, usermanager.GetRole(model.UserName))
                    
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity));
                
                return RedirectToAction("Index", "Home");

            } catch(ArgumentException ex)
            {
                ModelState.AddModelError(nameof(model.UserName), ex.Message);
                return View();
            }

        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
