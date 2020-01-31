using Microsoft.AspNet.Identity;
using Ninject;
using SalesStatistics.BLL.Services;
using SalesStatistics.Core.Interfaces;
using SalesStatistics.Core.Models;
using SalesStatistics.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SalesStatistics.DI.Utils
{
    public class NinjectResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;
        public NinjectResolver()
        {
            _kernel = new StandardKernel();
            AddBinding();

        }
        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
        private void AddBinding()
        {
            _kernel.Bind<IService<Product>>().To<ProductService>();
            _kernel.Bind<IService<Customer>>().To<CustomerService>();
            _kernel.Bind<IService<Manager>>().To<ManagerService>();
            _kernel.Bind<IService<Order>>().To<OrderService>();
            _kernel.Bind<IService<Report>>().To<ReportService>();
            _kernel.Bind<IRepository<Product>>().To<EfRepository<Product>>();
            _kernel.Bind<IRepository<Manager>>().To<EfRepository<Manager>>();
            _kernel.Bind<IRepository<Order>>().To<EfRepository<Order>>();
            _kernel.Bind<IRepository<Customer>>().To<EfRepository<Customer>>();
            _kernel.Bind<IRepository<Report>>().To<EfRepository<Report>>();
            _kernel.Bind<UserManager<User>>().To<SalesUserManager>();
            _kernel.Bind<RoleManager<Role>>().To<SalesRoleManager>();
            _kernel.Bind<IEfUnitOfWork>().To<IEFManager>();

        }
    }
}
