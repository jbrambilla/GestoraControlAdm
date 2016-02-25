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

            ToTable("Empresas");
        }
    }
}
