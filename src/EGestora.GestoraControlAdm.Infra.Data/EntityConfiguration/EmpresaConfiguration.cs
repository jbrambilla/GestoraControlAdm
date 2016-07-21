using EGestora.GestoraControlAdm.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EGestora.GestoraControlAdm.Infra.Data.EntityConfiguration
{
    public class EmpresaConfiguration : EntityTypeConfiguration<Empresa>
    {
        public EmpresaConfiguration()
        {
            HasKey(e => e.EmpresaId);

            HasRequired(e => e.Pessoa)
                .WithMany()
                .HasForeignKey(e => e.PessoaId);

            HasRequired(e => e.EnquadramentoServico)
                .WithMany(enq => enq.EmpresaList)
                .HasForeignKey(e => e.EnquadramentoServicoId);

            HasRequired(e => e.NaturezaOperacao)
                .WithMany(enq => enq.EmpresaList)
                .HasForeignKey(e => e.NaturezaOperacaoId);

            HasRequired(e => e.RegimeApuracao)
                .WithMany(enq => enq.EmpresaList)
                .HasForeignKey(e => e.RegimeApuracaoId);

            HasRequired(e => e.RegimeTributacao)
                .WithMany(enq => enq.EmpresaList)
                .HasForeignKey(e => e.RegimeTributacaoId);

            Ignore(e => e.Nome);

            ToTable("Empresas");
        }
    }
}
