using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team_Work.Migrations;
using Team_Work.Models;
using Team_Work.ViewModels;

namespace Team_Work.Controllers
{
    public class AccountController : Controller

    {
        private readonly SignInManager<AppUser> _signInManager;
        public readonly UserManager<AppUser> _userManager;
        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {


            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid) return View(register);

            AppUser user = new AppUser
            {
                UserName = register.UserName,
                Email = register.Email
            };
           


            IdentityResult result = await _userManager.CreateAsync(user,register.Password);
            if (!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("",error.Description);
                }
                return View(register);
            }

            return RedirectToAction("Index","Home");
        }
        public IActionResult Login()
        {
            return View();


            }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if(!ModelState.IsValid)
                return View(login);
            AppUser user = await _userManager.FindByNameAsync(login.UserName);

            if(user == null)
            {
                ModelState.AddModelError("", "Username or password is not correct");
                return View(login);
            }
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);
            if (result.Succeeded)
            {
                ModelState.AddModelError("", "Username or password is not correct");
                return View(login);
            }
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Test()
        {
            return Content(User.Identity.IsAuthenticated.ToString());
        }
    } }

