using EGestora.GestoraControlAdm.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EGestora.GestoraControlAdm.Infra.Data.EntityConfiguration
{
    public class LoteFaturamentoConfiguration : EntityTypeConfiguration<LoteFaturamento>
    {
        public LoteFaturamentoConfiguration()
        {
            HasKey(l => l.LoteFaturamentoId);

            HasMany(l => l.ClienteList)
                .WithMany(c => c.LoteFaturamentoList)
                .Map(me =>
                {
                    me.MapLeftKey("LoteFaturamentoId");
                    me.MapRightKey("PessoaId");
                    me.ToTable("LoteFaturamentoCliente");
                });

            Property(l => l.DataFechamento)
                .IsOptional();

            Property(l => l.Referencia)
                .IsOptional();

            Ignore(l => l.ValorTotalComNota);

            Ignore(l => l.ValorTotalSemNota);

            Ignore(l => l.ValorTotalGeral);

            Ignore(l => l.ValidationResult);

            ToTable("LoteFaturamento");
        }
    }
}
