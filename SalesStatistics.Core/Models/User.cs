using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesStatistics.Core.Models
{
    public class User : IdentityUser
    {
        public int UserRoleId { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }
    }
}
