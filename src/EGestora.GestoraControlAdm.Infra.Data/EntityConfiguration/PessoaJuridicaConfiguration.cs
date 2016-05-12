using EGestora.GestoraControlAdm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGestora.GestoraControlAdm.Infra.Data.EntityConfiguration
{
    public class PessoaJuridicaConfiguration : EntityTypeConfiguration<PessoaJuridica>
    {
        public PessoaJuridicaConfiguration()
        {
            HasKey(p => p.PessoaId);

            Property(c => c.Cnpj)
                .HasMaxLength(18);

            Property(c => c.RazaoSocial)
                 .HasMaxLength(100);

            HasRequired(pj => pj.RegimeImposto)
                .WithMany(ri => ri.PessoaJuridicaList)
                .HasForeignKey(pj => pj.RegimeImpostoId);

            HasRequired(pj => pj.Cnae)
                .WithMany()
                .HasForeignKey(pj => pj.CnaeId);

            HasMany(pj => pj.CnaeList)
                .WithMany()
                .Map(me =>
                {
                    me.MapLeftKey("PessoaId");
                    me.MapRightKey("CnaeId");
                    me.ToTable("PessoaCnae");
                });
        }
    }
}
