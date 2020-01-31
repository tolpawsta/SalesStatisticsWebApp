using System;
using System.ComponentModel.DataAnnotations;

namespace SalesStatistics.Core.Models
{
    public class Order
    {
        public long Id { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Дата заказа")]
        public DateTime OrderDate { get; set; }
        public int ReportId { get; set; }
        public virtual Report Report { get; set; }
        [Required]
        [RegularExpression(@"[0-9]*,[0-9]{2}", ErrorMessage = "Введите цену в формате ##,##")]
        public decimal Price { get; set; }

    }
}