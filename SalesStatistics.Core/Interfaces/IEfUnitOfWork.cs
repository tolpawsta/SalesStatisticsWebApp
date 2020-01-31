using SalesStatistics.Core.Models;

namespace SalesStatistics.Core.Interfaces
{
    public interface IEfUnitOfWork
    {
        IService<Customer> Customers { get; }
        IService<Product> Products { get; }
        IService<Manager> Managers { get; }
        IService<Order> Orders { get; }
        IService<Report> Reports { get; }
    }
}
