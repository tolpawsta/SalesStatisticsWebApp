using Ninject.Modules;
using SalesStatistics.BLL.Services;
using SalesStatistics.Core.Interfaces;
using SalesStatistics.Core.Models;
using SalesStatistics.DAL.Entities;

namespace SalesStatistics.DI.Utils
{
    public class Registration : NinjectModule
    {
        public override void Load()
        {
            Bind<IService<Product>>().To<ProductService>();
            Bind<IRepository<Product>>().To<EfRepository<Product>>();
        }
    }
}
