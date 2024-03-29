using Day_3_2.Models;
using Day_3_2.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Day_3_2.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]

        public IActionResult Register(User user)
        {
            ApplicationContext db = new ApplicationContext();
            db.Users.ToList();
            db.Users.Add(user);
            db.SaveChanges();
            //var role = db.Roles.FirstOrDefault(a => a.Name == "Students");
            //user.Roles.Add(role);
            //db.SaveChanges();
            return RedirectToAction("login");
        }
        [AllowAnonymous]

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]

        public async  Task<IActionResult> Login(LoginViewModel model)
        {
            ApplicationContext db = new ApplicationContext();
            var res = db.Users.Include(x=>x.Roles).FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
            if(res == null)
            {
                ModelState.AddModelError("","Invalid");
                return View(model);

            }
            Claim c1 = new Claim (ClaimTypes.Name , res.Name);
            Claim c2 = new Claim(ClaimTypes.Email, res.Email);
            List<Claim> Roleclaims = new List<Claim>();
            foreach(var item in res.Roles)
            {
                Roleclaims.Add(new Claim (ClaimTypes.Role, item.Name));
            }



            ClaimsIdentity ci = new ClaimsIdentity("Cookies");
            ci.AddClaim(c1);
            ci.AddClaim(c2);
            foreach (var item in Roleclaims)
            {
                ci.AddClaim(item);
            }

            ClaimsPrincipal cp = new ClaimsPrincipal();
                cp.AddIdentity(ci);
            await HttpContext.SignInAsync(cp);
            return RedirectToAction("index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("index", "home");

        }
    }
}
