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
            if (products==null)
            {
                ViewBag.Message = "Sorry product not found";
            }
            return View(products);
        }

        // GET: Product/Details/5
        public async Task<ActionResult> Details(int id=0)
        {
            var model = await _service.GetByIdAsync(id);
            if (model==null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Create");
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

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
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
