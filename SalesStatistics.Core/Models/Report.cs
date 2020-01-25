using System;

namespace SalesStatistics.Core.Models
{
    public class Report
    {
        public int Id { get; set; }
        public int ManagerId { get; set; }
        public virtual Manager Manager { get; set; }
        public DateTime ReportDate { get; set; }
    }
}