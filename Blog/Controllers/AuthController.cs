using Blog.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog
{
    public class AuthController : Controller
    {
        private SignInManager<IdentityUser> _signInManager;

        public AuthController ( SignInManager <IdentityUser> signInManager)
        {
            _signInManager = signInManager;
                
        }

        [HttpGet]
        public IActionResult Login ()
        {
            return View(new LoginViewModel () );
        }

        [HttpPost]
        public async Task<IActionResult> Login ( LoginViewModel l)
        {
            var rest = await _signInManager.PasswordSignInAsync(l.UserName, l.Password, false, false);
            return RedirectToAction("Index", "Panel");
        }

        [HttpGet]
        public async Task<IActionResult> Logout ()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
