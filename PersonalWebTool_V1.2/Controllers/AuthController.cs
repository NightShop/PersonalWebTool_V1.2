using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PersonalWebTool_V1.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string returnUrl, string username, string password)
        {
            var passwordHasher = new PasswordHasher<string>();
            bool passwordCorrect = passwordHasher.VerifyHashedPassword(null, "AQAAAAEAACcQAAAAEMlgNje3+SGzw9UcFR5cq+SVSEdK7EvDNM+zBlyJLwHSivybXpAs3qnt3dVvhQyWeQ==", password) == PasswordVerificationResult.Success;

            if (username == "Jon")
            {
                if (passwordCorrect)
                        {
                    var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, "jon", ClaimValueTypes.String, "https://yourdomain.com")
                        };
                    var userIdentity = new ClaimsIdentity(claims, "SecureLogin");
                    var userPrincipal = new ClaimsPrincipal(userIdentity);
                    //IsPersistent - deletes the cookie after closing browser if set to false
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        userPrincipal,
                        new AuthenticationProperties
                        {
                            ExpiresUtc = DateTime.UtcNow.AddHours(8),
                            IsPersistent = false,
                            AllowRefresh = false
                        });

                    return GoToReturnUrl(returnUrl);
                }
            }

            return RedirectToAction("Denied");
        }
        //Where to go after user is logged in
        private IActionResult GoToReturnUrl(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

        public IActionResult Denied()
        {
            return RedirectToAction("Login");
        }
    }
}
