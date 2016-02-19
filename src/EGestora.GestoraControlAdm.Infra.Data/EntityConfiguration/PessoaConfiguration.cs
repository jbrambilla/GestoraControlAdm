using EGestora.GestoraControlAdm.Domain.Entities;
using System.Data.Entity.ModelConfiguration;


namespace EGestora.GestoraControlAdm.Infra.Data.EntityConfiguration
{
    public class PessoaConfiguration : EntityTypeConfiguration<Pessoa>
    {
        public PessoaConfiguration()
        {
            HasKey(p => p.PessoaId);

            Property(p => p.Email)
                .IsRequired();

            Property(p => p.Ativo)
                .IsRequired();

            Property(p => p.CriadoEm)
                .IsRequired();

            Property(p => p.AlteradoEm)
                .IsRequired();

            HasOptional(p => p.PessoaFisica)
                    .WithRequired(pf => pf.Pessoa);

            HasOptional(p => p.PessoaJuridica)
                    .WithRequired(pf => pf.Pessoa);

            //HasOptional(x => x.PessoaFisica)
            //    .WithOptionalPrincipal(x => x.Pessoa);

            Ignore(p => p.ValidationResult);

            ToTable("Pessoa");
        }
    }
}
