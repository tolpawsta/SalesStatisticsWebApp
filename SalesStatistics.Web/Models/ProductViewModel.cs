using SalesStatistics.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesStatistics.Web.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Product> Products { get; set; }        
    }
}