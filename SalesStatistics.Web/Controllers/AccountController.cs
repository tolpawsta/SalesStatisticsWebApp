using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SalesStatistics.Core.Models;
using System.Web;
using System.Web.Mvc;
using SalesStatistics.BLL.Services;
using System.Threading.Tasks;
using SalesStatistics.Web.Models;
using System.Security.Claims;
using Microsoft.Owin.Security;

namespace SalesStatistics.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel details, string returnUrl)
        {
            User user = await UserManager.FindAsync(details.Name, details.Password);
            if (user == null)
            {
                ModelState.AddModelError("", "Некорректное имя или пароль.");
            }
            else
            {
                ClaimsIdentity ident = await UserManager.CreateIdentityAsync(user,
                DefaultAuthenticationTypes.ApplicationCookie);
                AuthManager.SignOut();
                AuthManager.SignIn(new AuthenticationProperties
                {
                    IsPersistent = false
                }, ident);
                return Redirect(returnUrl);
            }
            return View(details);
        }
        public ActionResult Registr()
        {
            ViewBag.Operation = "Зарегистрироваться";
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Registr(CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User() { UserName = model.Name, Email = model.Email };

                IdentityResult result =
                    await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View(model);
        }
        private IAuthenticationManager AuthManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        private SalesUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<SalesUserManager>();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
           AuthManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }
        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}
