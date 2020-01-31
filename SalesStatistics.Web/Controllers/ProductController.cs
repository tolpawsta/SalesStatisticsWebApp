using SalesStatistics.Core.Interfaces;
using SalesStatistics.Core.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SalesStatistics.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IService<Product> _service;

        public ProductController(IService<Product> service)
        {
            _service = service;
        }

        // GET: Product
        public async Task<ActionResult> Index()
        {
            var products = await _service.GetAllAsync();
            if (products == null)
            {
                ViewBag.Message = "Sorry product not found";
            }
            return View(products);
        }

        // GET: Product/Details/5
        public async Task<ActionResult> Details(int id = 0)
        {
            var model = await _service.GetByIdAsync(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<ActionResult> GetProductsFilter(string filterValue)
        {
            var products = await _service.GetEntitiesWhere(p => p.Name.Contains(filterValue) || p.Cost.ToString().Contains(filterValue));
            if (products == null)
            {
                ViewBag.Message = "Sorry product not found";
            }
            return View(products);
        }
       
        // GET: Product/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Product/Create
        [HttpPost]
       
        public async Task<ActionResult> Create(Product model)
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

        // GET: Product/Edit/5
        
        public ActionResult Edit(int id)
        {

            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        
        public async Task<ActionResult> Edit(Product model)
        {
            try
            {
                Product product = await _service.GetByIdAsync(model.Id);
                if (product != null)
                {
                    product.Name = model.Name;
                    product.Cost = model.Cost;
                    await _service.EditAsync(product);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Error = "Error";
                return View();
            }
        }
        public async Task<ActionResult> Delete(int id)
        {
            Product productDb = await _service.GetByIdAsync(id);
            if (productDb == null)
            {
                return RedirectToAction("Index");
            }
            return View(productDb);
        }
        // POST: Product/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, Product model)
        {
            try
            {
                Product product = await _service.GetByIdAsync(id);
                if (product != null)
                {
                    await _service.DeleteAsync(product);
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
