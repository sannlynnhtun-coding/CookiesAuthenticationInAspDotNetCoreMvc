using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CookiesAuthenticationInAspDotNetCoreMvc.Controllers {
    public class AuthenticationController : Controller {
        public IActionResult Index() {
            return View();
        }

        public async Task<IActionResult> Login() {
            var claims = new List<Claim>() {
                new Claim("UserName",  "SLH")
        };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));
            return Redirect("/Home");
        }

        public async Task<IActionResult> Logout() {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
