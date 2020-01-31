using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using SalesStatistics.Core.Models;
using SalesStatistics.DAL.Entities;

namespace SalesStatistics.BLL.Services
{
    public class SalesRoleManager : RoleManager<Role>
    {
        public SalesRoleManager(IRoleStore<Role, string> store) : base(store)
        {
        }
        public static SalesRoleManager Create(IdentityFactoryOptions<SalesRoleManager> options,
           IOwinContext context)
        {
            RoleStore<Role> store = new RoleStore<Role>(context.Get<AppDbContext>());
            return new SalesRoleManager(store);
        }
    }
}
