using SalesStatistics.Core.Interfaces;
using SalesStatistics.Core.Models;
using SalesStatistics.Web.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SalesStatistics.Web.Controllers
{
    public class OrderController : Controller
    {
        public readonly IService<Order> _dbOrders;
        public readonly IService<Customer> _dbCustomers;
        public readonly IService<Product> _dbProducts;
        public readonly IService<Report> _dbReports;
        public readonly IService<Manager> _dbManagers;



        public OrderController(IService<Order> dbOrders, IService<Customer> dbCustomers, IService<Product> dbProducts, IService<Report> dbReports, IService<Manager> dbManagers)
        {
            _dbOrders = dbOrders;
            _dbCustomers = dbCustomers;
            _dbProducts = dbProducts;
            _dbReports = dbReports;
            _dbManagers = dbManagers;
        }

        // GET: Order
        public async Task<ActionResult> Index()
        {
            var orders = await _dbOrders.GetAllAsync();
            return View(orders);
        }

        // GET: Order/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var order = await _dbOrders.GetByIdAsync(id);
            return View(order);
        }

        // GET: Order/Create
        public async Task<ActionResult> Create()
        {
            var customers = await _dbCustomers.GetAllAsync();
            var products = await _dbProducts.GetAllAsync();
            var managers = await _dbManagers.GetAllAsync();
            if (customers == null || customers.Count() == 0)
            {
                return RedirectToAction("Create", "Customer");
            }
            if (products == null || products.Count() == 0)
            {
                return RedirectToAction("Create", "Product");
            }
            if (managers == null || managers.Count() == 0)
            {
                return RedirectToAction("Create", "Manager");
            }
            OrderCreateViewModel orderVM = new OrderCreateViewModel();
            orderVM.Products = new SelectList(products, "Id", "Name");
            orderVM.Customers = new SelectList(customers, "Id", "LastName");
            orderVM.Managers = new SelectList(managers, "Id", "LastName");
            return View(orderVM);
        }

        // POST: Order/Create
        [HttpPost]
        public async Task<ActionResult> Create(OrderCreateViewModel model)
        {
            if (model != null)
            {
                try
                {
                    Report report = new Report()
                    {
                        ManagerId = model.ManagerId,
                        ReportDate = model.ReportDate,
                    };
                    await _dbReports.CreateAsync(report);
                    var reports = await _dbReports.GetAllAsync();
                    Order order = new Order()
                    {
                        CustomerId = model.CustomerId,
                        Customer = await _dbCustomers.GetByIdAsync(model.CustomerId),
                        ProductId = model.ProductId,
                        Product = await _dbProducts.GetByIdAsync(model.ProductId),
                        Price = model.Price,
                        ReportId = reports.FirstOrDefault().Id,
                        Report = await _dbReports.GetByIdAsync(reports.FirstOrDefault().Id)
                        
                    };
                    await _dbOrders.CreateAsync(order);
                    return RedirectToAction("Index");

                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
