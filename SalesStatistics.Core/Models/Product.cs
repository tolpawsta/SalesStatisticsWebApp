using System.Collections.Generic;

namespace SalesStatistics.Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public Product()
        {
            Orders = new HashSet<Order>();
        }
    }
}
