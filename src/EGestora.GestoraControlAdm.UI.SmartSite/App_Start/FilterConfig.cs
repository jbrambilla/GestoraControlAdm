using System.Web;
using System.Web.Mvc;

namespace EGestora.GestoraControlAdm.UI.SmartSite
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
