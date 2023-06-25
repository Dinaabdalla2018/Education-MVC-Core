using Day2.Models;
using Day2.Repository;
using Day2.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Day2.Controllers
{
    public class AccountController : Controller
    {
        IAccountRepository accountRepository;
        public AccountController(IAccountRepository _accountRepository)
        {
            accountRepository = _accountRepository;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Register_NewAccount _account)
        {
            if(ModelState.IsValid)
            {
                Account a=new Account();
                a.UserName = _account.UserName;
                a.Password = _account.Password;
                accountRepository.CreateAccount(a);
                accountRepository.Save();

                ////////Cookie
                
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, a.Id + ""));
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, a.UserName));
                //Get Role of user Admin or student
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, accountRepository.GetRoles(a.Id)));
                ClaimsPrincipal claimsPrincipal =new ClaimsPrincipal(claimsIdentity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
                return RedirectToAction("index", "Course");
            }
            return View(_account);
        }
       
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Account account)
        {
            if (accountRepository.Find(account.UserName, account.Password))
            {
                Account accountM = accountRepository.GetAccount(account.UserName);
                //Cookie
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, account.Id + ""));
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, account.UserName));
                //Get Role of user Admin or student
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, accountRepository.GetRoles(account.Id)));
                
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
                return RedirectToAction("index", "Course");
            }
            return View(account);
        }
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View("Login");
        }
    }
}
