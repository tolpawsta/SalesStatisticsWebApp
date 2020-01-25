using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace SalesStatistics.Core.Models
{
    public class User: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public int UserRoleId { get; set; }
        public virtual ICollection<IdentityUserRole> UserRoles { get; set; }
        public User()
        {
            UserRoles = new HashSet<IdentityUserRole>();
        }

    }
}
