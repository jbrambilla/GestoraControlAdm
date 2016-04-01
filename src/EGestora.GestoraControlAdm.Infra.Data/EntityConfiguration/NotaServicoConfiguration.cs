using EGestora.GestoraControlAdm.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EGestora.GestoraControlAdm.Infra.Data.EntityConfiguration
{
    public class NotaServicoConfiguration : EntityTypeConfiguration<NotaServico>
    {
        public NotaServicoConfiguration()
        {
            HasKey(n => n.NotaServicoId);

            HasRequired(n => n.Empresa)
                .WithMany(e => e.NotaServicoList)
                .HasForeignKey(n => n.EmpresaId);

            HasRequired(n => n.Cliente)
                .WithMany(e => e.NotaServicoList)
                .HasForeignKey(n => n.ClienteId);

            Property(n => n.OutrasInformacoes)
                .HasColumnType("text");

            Property(n => n.DiscriminacaoServico)
                .HasColumnType("text");

            Property(n => n.Xml)
                .HasColumnType("text")
                .HasMaxLength(8000);

            Ignore(n => n.ValidationResult);

            Ignore(n => n.Emitir);

            Ignore(n => n.EnviarEmail);

            Ignore(n => n.PdfNfse);

            ToTable("NotaServico");
        }
    }
}
