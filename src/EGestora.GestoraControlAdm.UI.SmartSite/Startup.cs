using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EGestora.GestoraControlAdm.UI.SmartSite.Startup))]
namespace EGestora.GestoraControlAdm.UI.SmartSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}