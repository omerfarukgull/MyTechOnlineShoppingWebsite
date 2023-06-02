using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyTechWebUı.EmailSevices;
using MyTechWebUı.Identity;
using MyTechWebUı.Models;
using Newtonsoft.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MyTechWebUı.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private IEmailSender _emailSender;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user == null)
                {
                    ModelState.AddModelError("", "Bu kullanıcı adına ait hesap bulunamadı.");
                    return View(model);
                }
                if (!await _userManager.IsEmailConfirmedAsync(user))
                {
                    ModelState.AddModelError("", "Lütfen email hesabınıza gelen link ile üyeliğinizi onaylayın");
                    return View(model);
                }
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

                var admin = await _userManager.IsInRoleAsync(user, "admin");
                if (admin)
                {
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                }
                else
                {
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.UserName,
                    Email = model.Email,
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "customer");
                    var codeToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var url = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token = codeToken });

                    await _emailSender.SendEmailAsync(model.Email, "Hesabınızı Onaylayınız", $"Lütfen email hesabınız onaylamak için linke <a href='https://localhost:7167{url}'>tıklayınız.</a>");

                    return RedirectToAction(nameof(Login));
                }
            }
            ModelState.AddModelError("", "Bilinmeyen hata oldu lütfen tekrar deneyiniz.");
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                CreateMessage("Geçersiz token.", "danger");
                return View();

            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    CreateMessage("Hesabınız onaylandı. Lütfen giriş yapınız.", "success");
                    return View();
                }
            }
            CreateMessage("Hesabınızı onaylanmadı.", "warning");
            return View();
        }
        private void CreateMessage(string message, string alerttype)
        {
            var msg = new AlertMessage()
            {
                Message = message,
                AlertType = alerttype
            };
            TempData["message"] = JsonConvert.SerializeObject(msg);
        }

        public IActionResult ForgotPassword()
        {
            return View(); ;
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string Email)
        {
            if (string.IsNullOrEmpty(Email))
            {
                return View();
            }
            var user = await _userManager.FindByEmailAsync(Email);
            if (user == null)
            {
                CreateMessage("Kullanıcı Bulunamadı", "warning");
                return View();
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var url = Url.Action("ResetPassword", "Account", new { userId = user.Id, token = token });

            await _emailSender.SendEmailAsync(Email, "Şifre Yenile", $"Şifre yenilemek için lütfen linke <a href='https://localhost:7167{url}'>tıklayınız.</a>");
            return View();
        }
        public IActionResult ResetPassword(string userId, string token)
        {
            if (userId == null || token == null)
            {
                CreateMessage("Şifre Değiştirilemedi", "warning");
                return RedirectToAction("Index", "Home");
            }
            var model = new ResetPasswordModel
            { Token = token };
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                CreateMessage("Kullanıcı bulunamadı.", "warning");
                return View();
            }
            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (result.Succeeded)
            {
                CreateMessage("Şifre başarılı bir şekilde değişti.", "success");
                return RedirectToAction(nameof(Login));
            }
            return View();
        }
    }
}
