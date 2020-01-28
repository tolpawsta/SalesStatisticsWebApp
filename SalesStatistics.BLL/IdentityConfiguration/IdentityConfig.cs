using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using SalesStatistics.BLL.Services;
using SalesStatistics.Core.Models;
using SalesStatistics.DAL.Entities;

namespace SalesStatistics.BLL.IdentityConfiguration
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<AppDbContext>(AppDbContext.Create);
            app.CreatePerOwinContext<SalesUserManager>(SalesUserManager.Create);
            app.CreatePerOwinContext<RoleManager<Role>>((option, context) =>
            new RoleManager<Role>(
                new RoleStore<Role>(context.Get<AppDbContext>())));
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {

                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath=new PathString("/Account/Login"),
            });
        }
    }
}
