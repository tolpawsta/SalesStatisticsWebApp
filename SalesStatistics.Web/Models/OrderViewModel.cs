using SalesStatistics.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SalesStatistics.Web.Models
{
    public class OrderEditViewModel
    {
        public List<Product> Products { get; set; }
        public Product SelectidProduct { get; set; }      
        public List<Customer> Customers { get; set; }
        public Customer SelectedCustomer { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
    }
    public class OrderCreateViewModel
    {        
        public IEnumerable<SelectListItem> Products { get; set; }
        public IEnumerable<SelectListItem> Customers { get; set; }
        public IEnumerable<SelectListItem> Managers { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int ManagerId { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ReportDate { get; set; }
       
    }
}