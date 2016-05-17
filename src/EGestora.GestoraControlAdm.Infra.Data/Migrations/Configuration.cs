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
            context.RegimeImposto.AddOrUpdate(
                ri => ri.Descricao,
                new RegimeImposto() { Descricao = "Regime Imposto 1" },
                new RegimeImposto() { Descricao = "Regime Imposto 2" }
            );

            context.Cnaes.AddOrUpdate(
               c => c.Codigo,
               new Cnae() { Codigo = "1", Descricao = "Cnae 1" },
               new Cnae() { Codigo = "2", Descricao = "Cnae 2" },
               new Cnae() { Codigo = "3", Descricao = "Cnae 3" }
            );

            context.TipoContato.AddOrUpdate(
                tc => tc.Nome,
                new TipoContato() { Nome = "Telefone", Mascara = "(00) 0000-0000" },
                new TipoContato() { Nome = "Celular", Mascara = "(00) 00000-0000" }
            );

            context.RegimeTributacao.AddOrUpdate(
                rt => rt.Codigo,
                new RegimeTributacao() { Codigo = 1, Descricao = "Regime T 1" },
                new RegimeTributacao() { Codigo = 2, Descricao = "Regime T 2" },
                new RegimeTributacao() { Codigo = 3, Descricao = "Regime T 3" }
            );

            context.RegimeApuracao.AddOrUpdate(
                rt => rt.Codigo,
                new RegimeApuracao() { Codigo = 1, Descricao = "Regime A 1" },
                new RegimeApuracao() { Codigo = 2, Descricao = "Regime A 2" },
                new RegimeApuracao() { Codigo = 3, Descricao = "Regime A 3" }
            );

            context.NaturezaOperacao.AddOrUpdate(
                no => no.Codigo,
                new NaturezaOperacao() { Codigo = 1, Descricao = "Natureza 1" },
                new NaturezaOperacao() { Codigo = 2, Descricao = "Natureza 2" },
                new NaturezaOperacao() { Codigo = 3, Descricao = "Natureza 3" }
           );

            context.EnquadramentoServico.AddOrUpdate(
                es => es.Codigo,
                new EnquadramentoServico() { Codigo = "1", Descricao = "Enquadramento 1" },
                new EnquadramentoServico() { Codigo = "2", Descricao = "Enquadramento 2" },
                new EnquadramentoServico() { Codigo = "3", Descricao = "Enquadramento 3" }
            );

            context.Servicos.AddOrUpdate(
                s => s.Descricao,
                new Servico() { Descricao = "Servico 1", Valor = 25.50M },
                new Servico() { Descricao = "Servico 2", Valor = 33.60M },
                new Servico() { Descricao = "Servico 3", Valor = 125.30M },
                new Servico() { Descricao = "Servico 4", Valor = 50 },
                new Servico() { Descricao = "Servico 5", Valor = 700 }
            );

            context.Profissao.AddOrUpdate(
                p => p.Nome,
                new Profissao() { Nome = "Marceneiro" },
                new Profissao() { Nome = "Empresário" },
                new Profissao() { Nome = "Carpitnteiro" }
            );

            context.Cargo.AddOrUpdate(
                c => c.Nome,
                new Cargo() { Nome = "Programmer I" },
                new Cargo() { Nome = "Programmer II" },
                new Cargo() { Nome = "Analist" }
            );
        }
    }
}
