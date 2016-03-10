namespace EGestora.GestoraControlAdm.Infra.Data.Migrations
{
    using EGestora.GestoraControlAdm.Domain.Entities;
    using EGestora.GestoraControlAdm.Infra.Data.Context;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EGestora.GestoraControlAdm.Infra.Data.Context.EGestoraContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EGestoraContext context)
        {
           // context.RegimeApuracao.AddOrUpdate (
           //     new RegimeApuracao() { Codigo = 1, Descricao = "Regime A 1"},
           //     new RegimeApuracao() { Codigo = 2, Descricao = "Regime A 2" },
           //     new RegimeApuracao() { Codigo = 3, Descricao = "Regime A 3" }
           // );

           // context.RegimeTributacao.AddOrUpdate(
           //     new RegimeTributacao() { Codigo = 1, Descricao = "Regime T 1" },
           //     new RegimeTributacao() { Codigo = 2, Descricao = "Regime T 2" },
           //     new RegimeTributacao() { Codigo = 3, Descricao = "Regime T 3" }
           // );

           // context.NaturezaOperacao.AddOrUpdate(
           //    new NaturezaOperacao() { Codigo = 1, Descricao = "Natureza 1" },
           //    new NaturezaOperacao() { Codigo = 2, Descricao = "Natureza 2" },
           //    new NaturezaOperacao() { Codigo = 3, Descricao = "Natureza 3" }
           //);

           // context.EnquadramentoServico.AddOrUpdate(
           //    new EnquadramentoServico() { Codigo = "1", Descricao = "Enquadramento 1" },
           //    new EnquadramentoServico() { Codigo = "2", Descricao = "Enquadramento 2" },
           //    new EnquadramentoServico() { Codigo = "3", Descricao = "Enquadramento 3" }
           // );

           // context.Cnaes.AddOrUpdate(
           //    new Cnae() { Codigo = "1", Descricao = "Cnae 1" },
           //    new Cnae() { Codigo = "2", Descricao = "Cnae 2" },
           //    new Cnae() { Codigo = "3", Descricao = "Cnae 3" }
           // );

           // context.Servicos.AddOrUpdate(
           //     new Servico() { Descricao = "Servico 1", Valor = 25.50M },
           //     new Servico() { Descricao = "Servico 2", Valor = 33.60M},
           //     new Servico() { Descricao = "Servico 3", Valor = 125.30M },
           //     new Servico() { Descricao = "Servico 4", Valor = 50 },
           //     new Servico() { Descricao = "Servico 5", Valor = 700 }
           // );
        }
    }
}
