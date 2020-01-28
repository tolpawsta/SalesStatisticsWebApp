using SalesStatistics.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesStatistics.Web.Models
{
    public class OrderEditCreateViewModel
    {
        public List<Product> Products { get; set; }
        public Product SelectidProduct { get; set; }
        public List<Customer> Customers { get; set; }
        public Customer SelectedCustomer { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
    }
}