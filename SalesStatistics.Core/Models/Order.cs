using System;

namespace SalesStatistics.Core.Models
{
    public class Order
    {
        public long Id { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public DateTime OrderDate { get; set; }
        public int ReportId { get; set; }
        public virtual Report Report { get; set; }
        public decimal Price { get; set; }

    }
}