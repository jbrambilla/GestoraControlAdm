using EGestora.GestoraControlAdm.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EGestora.GestoraControlAdm.Infra.Data.EntityConfiguration
{
    public class EmpresaConfiguration : EntityTypeConfiguration<Empresa>
    {
        public EmpresaConfiguration()
        {
            HasKey(e => e.PessoaId);

            HasMany(f => f.CnaeList)
                .WithMany()
                .Map(me =>
                {
                    me.MapLeftKey("PessoaId");
                    me.MapRightKey("CnaeId");
                    me.ToTable("EmpresaCnae");
                });

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

            ToTable("Empresas");
        }
    }
}
