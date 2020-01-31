using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SalesStatistics.BLL.Services;
using SalesStatistics.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SalesStatistics.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private SalesUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<SalesUserManager>();
            }
        }
        private SalesRoleManager RoleManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<SalesRoleManager>();
            }
        }
        public ActionResult Index()
        {
            return View(RoleManager.Roles);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create([Required]string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result
                = await RoleManager.CreateAsync(new Role(name));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View(name);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            Role role = await RoleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await RoleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error", result.Errors);
                }
            }
            else
            {
                return View("Error", new string[] { "Роль не найдена" });
            }
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
