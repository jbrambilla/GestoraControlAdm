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
            HasKey(p => p.PessoaJuridicaId);

            Property(c => c.Cnpj)
                .HasMaxLength(14);

            Property(c => c.RazaoSocial)
                 .HasMaxLength(100);

            // MAPEAMENTO DE UM PARA MUITOS
            //HasRequired(p => p.Pessoa)
            //    .WithMany(p => p.PessoaJuridicaList)
            //    .HasForeignKey(p => p.PessoaId);

            // MAPEAMENTO DE MUITOS PARA MUITOS
            HasMany(f => f.EnderecoList)
                .WithMany()
                .Map(me =>
                {
                    me.MapLeftKey("PessoaJuridicaId");
                    me.MapRightKey("EnderecoId");
                    me.ToTable("PessoaJuridicaEndereco");
                });

        }
    }
}
