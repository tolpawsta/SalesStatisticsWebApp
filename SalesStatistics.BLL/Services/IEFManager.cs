using SalesStatistics.Core.Interfaces;
using SalesStatistics.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesStatistics.BLL.Services
{
    public class IEFManager : IEfUnitOfWork
    {
        public IService<Customer> Customers { get; set; }

        public IService<Product> Products { get; set; }

        public IService<Manager> Managers { get; set; }

        public IService<Order> Orders { get; set; }

        public IService<Report> Reports { get; set; }

        public IEFManager(IService<Customer> customers, IService<Product> products, IService<Manager> managers, IService<Order> orders, IService<Report> reports)
        {
            Customers = customers;
            Products = products;
            Managers = managers;
            Orders = orders;
            Reports = reports;
        }
    }
}
