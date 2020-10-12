using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace TicketService.Controllers
{
    public class LanguageController : Controller
    {
        public IActionResult SetLanguage(string locale)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(locale)));
            
            return RedirectToAction("Index", "Events");
        }
    }
}
