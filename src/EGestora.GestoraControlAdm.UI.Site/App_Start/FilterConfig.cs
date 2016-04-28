using EGestora.GestoraControlAdm.Infra.CrossCutting.MvcFilters;
using System.Web;
using System.Web.Mvc;

namespace EGestora.GestoraControlAdm.UI.Site
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            filters.Add(new AuthorizeAttribute());

            filters.Add(new AuditAttribute());
        }
    }
}
