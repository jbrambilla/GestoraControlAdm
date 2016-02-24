using System;
using System.Linq;
using System.Web.Mvc;

namespace EGestora.GestoraControlAdm.UI.Site.ViewEngine
{
    public class GestoraControlAdmViewEngine: RazorViewEngine
    {
        private static string[] NewPartialViewFormats = new[] { 
            "~/Views/{1}/Partials/{0}.cshtml",
            "~/Views/Clientes/Cnaes/{0}.cshtml",
            "~/Views/Clientes/Servicos/{0}.cshtml",
            "~/Views/Shared/Pessoa/{0}.cshtml",
            "~/Views/Shared/Pessoa/Endereco/{0}.cshtml"
        };

        public GestoraControlAdmViewEngine()
        {
            base.PartialViewLocationFormats = base.PartialViewLocationFormats.Union(NewPartialViewFormats).ToArray();
        }     
    }
}