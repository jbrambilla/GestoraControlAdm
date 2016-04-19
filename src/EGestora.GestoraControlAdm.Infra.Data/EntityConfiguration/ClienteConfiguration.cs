using EGestora.GestoraControlAdm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGestora.GestoraControlAdm.Infra.Data.EntityConfiguration
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            HasKey(c => c.PessoaId);

            Property(p => p.VencimentoBoleto)
                .IsRequired();

            Property(p => p.ComNota)
                .IsRequired();

            HasRequired(c => c.Cnae)
                .WithMany()
                .HasForeignKey(c => c.CnaeId);

            HasMany(f => f.CnaeList)
                .WithMany()
                .Map(me =>
                {
                    me.MapLeftKey("PessoaId");
                    me.MapRightKey("CnaeId");
                    me.ToTable("ClienteCnae");
                });

            HasMany(c => c.ClienteServicoList)
                .WithRequired(cs => cs.Cliente)
                .HasForeignKey(cs => cs.PessoaId);

            HasOptional(c => c.Revenda)
                .WithMany(r => r.ClienteList)
                .HasForeignKey(c => c.RevendaId);

            HasRequired(c => c.RegimeApuracao)
                .WithMany(r => r.ClienteList)
                .HasForeignKey(c => c.RegimeApuracaoId);

            Ignore(c => c.ValorTotalServicos);

            Ignore(c => c.DiscriminacaoServicos);

            ToTable("Clientes");
        }
    }
}
