using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EGestora.GestoraControlAdm.UI.Site.Startup))]
namespace EGestora.GestoraControlAdm.UI.Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
