using Microsoft.AspNet.Identity;
using SalesStatistics.Core.Models;

namespace SalesStatistics.DAL.Identity
{
    public class ApplicationUserManager:UserManager<User>
    {
        public ApplicationUserManager(IUserStore<User> store):base(store)
        {

        }
    }
}
