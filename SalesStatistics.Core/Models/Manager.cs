using System.Collections.Generic;

namespace SalesStatistics.Core.Models
{
    public class Manager
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ReportId { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        public Manager()
        {
            Reports = new HashSet<Report>();
        }
    }
}