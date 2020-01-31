using SalesStatistics.Core.Interfaces;
using SalesStatistics.Core.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SalesStatistics.Web.Controllers
{
    public class ManagerController : Controller
    {
        private readonly IService<Manager> _service;
        public ManagerController(IService<Manager> service)
        {
            _service = service;
        }
        // GET: Manager
        public async Task<ActionResult> Index()
        {
            var managers = await _service.GetAllAsync();
            return View(managers);
        }

        // GET: Manager/Details/5
        public async Task<ActionResult> Details(int id = 0)
        {
            var manager = await _service.GetByIdAsync(id);
            if (manager != null)
            {
                return RedirectToAction("Index");
            }
            return View(manager);
        }

        // GET: Manager/Create
        [Authorize(Roles ="Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manager/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create(Manager model)
        {
            try
            {
                await _service.CreateAsync(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Manager/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Manager/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(Manager model)
        {
            try
            {
                Manager manager = await _service.GetByIdAsync(model.Id);
                if (manager!=null)
                {
                    manager.FirstName = model.FirstName;
                    manager.LastName = model.LastName;
                    await _service.EditAsync(manager);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Admin")]
        // GET: Manager/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Manager managerDb = await _service.GetByIdAsync(id);
            if (managerDb==null)
            {
                return RedirectToAction("Index");
            }
            return View(managerDb);
        }

        // POST: Manager/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int id,Manager model)
        {
            try
            {
                Manager manager = await _service.GetByIdAsync(id);
                if (manager != null)
                {
                    await _service.DeleteAsync(manager);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
