using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SalesStatistics.Core.Models;
using System.Web;
using System.Web.Mvc;
using SalesStatistics.BLL.Services;
using System.Threading.Tasks;
using SalesStatistics.Web.Models;

namespace SalesStatistics.Web.Controllers
{
    public class AdminController : Controller
    {

        // GET: User
        public ActionResult Index()
        {
            return View(UserManager.Users);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(CreateModel model)
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
        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        private SalesUserManager UserManager => HttpContext.GetOwinContext().GetUserManager<SalesUserManager>();

    }
}