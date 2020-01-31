using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using SalesStatistics.BLL.Identity;
using SalesStatistics.Core.Models;
using SalesStatistics.DAL.Entities;

namespace SalesStatistics.BLL.Services
{
    public class SalesUserManager : UserManager<User>
    {
        public SalesUserManager(IUserStore<User> store) : base(store)
        {

        }
        public static SalesUserManager Create(IdentityFactoryOptions<SalesUserManager> options,
           IOwinContext context)
        {
            UserStore<User> store =new UserStore<User>(context.Get<AppDbContext>());
            SalesUserManager manager = new SalesUserManager(store);
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = true,
                RequireUppercase = true
            };
            manager.UserValidator = new AppUserValidator();            
            return manager;
        }
    }
}
