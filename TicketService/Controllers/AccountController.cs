using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TicketService.Controllers
{

    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Events");
        }
        public async Task<IActionResult> UserInfo(string userName)
        {
            var user = await userManager.FindByNameAsync(userName);
            return View(user);
        }
        public async Task<IActionResult> EditUserInfo(IdentityUser user)
        {
            var _user = await userManager.FindByIdAsync(user.Id);
            await userManager.SetEmailAsync(_user, user.Email);
            await userManager.SetUserNameAsync(_user, user.UserName);
            return RedirectToAction("Index", "Events");
        }
    }
}
