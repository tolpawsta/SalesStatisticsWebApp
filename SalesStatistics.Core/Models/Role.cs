﻿using Microsoft.AspNet.Identity.EntityFramework;
namespace SalesStatistics.Core.Models
{
    public class Role : IdentityRole
    {
        public Role() : base() { }
        public Role(string name) : base(name) { }
    }
}
