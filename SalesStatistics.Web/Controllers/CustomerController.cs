using SalesStatistics.Core.Interfaces;
using SalesStatistics.Core.Models;
using SalesStatistics.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SalesStatistics.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IService<Customer> _service;

        public CustomerController(IService<Customer> service)
        {
            _service = service;
        }

        // GET: Customer
        public async Task<ActionResult> Index()
        {
            var customers = await _service.GetAllAsync();
            if (customers == null || customers.Count()==0)
            {
                ViewBag.Message = "Sorry product not found";
            }
            return View(customers);
        }

        // GET: Customer/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = await _service.GetByIdAsync(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        
        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
       
        public async Task<ActionResult> Create(Customer model)
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

        // GET: Customer/Edit/5
       
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(CreateEditViewModel model)
        {
            try
            {
                Customer castomer = await _service.GetByIdAsync(model.Id);
                if (castomer != null)
                {
                    castomer.FirstName = model.FirstName;
                    castomer.LastName = model.LastName;
                    await _service.EditAsync(castomer);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Error = "Error";
                return View();
            }
        }

        // GET: Customer/Delete/5
        
        public async Task<ActionResult> Delete(int id)
        {
            Customer customerDb = await _service.GetByIdAsync(id);
            if (customerDb == null)
            {
                return RedirectToAction("Index");
            }
            return View(customerDb);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                Customer customer = await _service.GetByIdAsync(id);
                if (customer != null)
                {
                    await _service.DeleteAsync(customer);
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
