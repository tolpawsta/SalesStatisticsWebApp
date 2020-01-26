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
            _kernel.Bind<IRepository<Product>>().To<EfRepository<Product>>();
        }
    }
}
