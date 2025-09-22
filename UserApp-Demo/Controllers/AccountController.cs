using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net.Mail;
using UserApp_Demo.Models;
using UserApp_Demo.ViewModels;
namespace UserApp_Demo.Controllers
{
    public class AccountController(SignInManager<User> _signInManager, UserManager<User> _userManager) : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var address = new MailAddress(model.Email);
            var userName = address.User;
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(userName, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");
                else
                {

                    ModelState.AddModelError("", "Email or Password is incorrect");
                    return View(model);
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //extracting the username part
                string userName = model.Email;
                var address = new MailAddress(model.Email);
                userName = address.User;

                User user = new User
                {
                    FullName = model.Name,
                    Email = model.Email,
                    //UserName = model.Email.Split('@')[0]
                    UserName = userName
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                    return RedirectToAction("Login", "Account");
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }
            }
            return View(model);


        }
        [HttpGet]
        public IActionResult VerifyEmail()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }
    }
}
