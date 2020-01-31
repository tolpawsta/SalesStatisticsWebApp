using Microsoft.AspNet.Identity.Owin;
using SalesStatistics.BLL.Services;
using System.Web;
using System.Web.Mvc;

namespace SalesStatistics.Web.Helpers
{
    public static class IdentityHelpers
    {
        public static MvcHtmlString GetUserName(this HtmlHelper html, string id)
        {
            SalesUserManager mgr = HttpContext.Current
            .GetOwinContext().GetUserManager<SalesUserManager>();
            return new MvcHtmlString(mgr.FindByIdAsync(id).Result.UserName);
        }
    }
}