using SalesStatistics.Core.Interfaces;
using SalesStatistics.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SalesStatistics.Web.Controllers
{
    public class OrderController : Controller
    {
        public readonly IService<Order> _dbOrders;
        public readonly IService<Customer> _dbCustomers;
        public readonly IService<Product> _dbProducts;

        public OrderController(IService<Order> dbOrders, IService<Customer> dbCustomers, IService<Product> dbProducts)
        {
            _dbOrders = dbOrders;
            _dbCustomers = dbCustomers;
            _dbProducts = dbProducts;
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
            var order =await _dbOrders.GetByIdAsync(id);
            return View(order);
        }

        // GET: Order/Create
        public async Task<ActionResult> Create()
        {
            var customers = await _dbCustomers.GetAllAsync();
            var products = await _dbProducts.GetAllAsync();
            if (customers==null)
            {
                return RedirectToAction("Create","Customer");
            }
            if (products == null)
            {
                return RedirectToAction("Create", "Product");
            }
            ViewBag.Customers = new SelectList(customers, "Id", "Fistname" + " " + "Lastname");
            ViewBag.Products = new SelectList(products, "Id", "Name");
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
