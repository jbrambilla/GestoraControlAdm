﻿using System;
using System.Linq;
using System.Web.Mvc;

namespace EGestora.GestoraControlAdm.UI.Site.ViewEngine
{
    public class GestoraControlAdmViewEngine: RazorViewEngine
    {
        private static string[] NewPartialViewFormats = new[] { 
            "~/Views/{1}/Partials/{0}.cshtml",
            "~/Views/Pessoas/Funcionarios/{0}.cshtml",
            "~/Views/Pessoas/Proprietarios/{0}.cshtml",
            "~/Views/Pessoas/PessoaPartial/{0}.cshtml",
            "~/Views/Clientes/Servicos/{0}.cshtml",
            "~/Views/Clientes/Revendas/{0}.cshtml",
            "~/Views/Clientes/Debitos/{0}.cshtml",
            "~/Views/Clientes/CodigoSegurancas/{0}.cshtml",
            "~/Views/Clientes/Imagem/{0}.cshtml",
            "~/Views/LoteFaturamentos/Servico/{0}.cshtml",
            "~/Views/Debitos/Boletos/{0}.cshtml",
            "~/Views/Audit/Action/{0}.cshtml",
            "~/Views/Shared/Pessoa/{0}.cshtml",
            "~/Views/Shared/Pessoa/Cnae/{0}.cshtml",
            "~/Views/Shared/Pessoa/Endereco/{0}.cshtml",
            "~/Views/Shared/Pessoa/Contato/{0}.cshtml",
            "~/Views/Shared/Pessoa/Anexo/{0}.cshtml"
        };

        public GestoraControlAdmViewEngine()
        {
            base.PartialViewLocationFormats = base.PartialViewLocationFormats.Union(NewPartialViewFormats).ToArray();
        }     
    }
}