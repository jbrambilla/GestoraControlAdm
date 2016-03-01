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
            context.RegimeApuracao.AddOrUpdate (
                new RegimeApuracao() { Codigo = 1, Descricao = "Regime 1"},
                new RegimeApuracao() { Codigo = 2, Descricao = "Regime 2" },
                new RegimeApuracao() { Codigo = 3, Descricao = "Regime 3" }
            );

            context.Servicos.AddOrUpdate(
                new Servico() { Descricao = "Servico 1", Valor = 25.50M },
                new Servico() { Descricao = "Servico 2", Valor = 33.60M},
                new Servico() { Descricao = "Servico 3", Valor = 125.30M },
                new Servico() { Descricao = "Servico 4", Valor = 50 },
                new Servico() { Descricao = "Servico 5", Valor = 700 }
            );
        }
    }
}
