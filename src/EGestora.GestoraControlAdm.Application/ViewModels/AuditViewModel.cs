using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace EGestora.GestoraControlAdm.Application.ViewModels
{
    public class AuditViewModel
    {
        public AuditViewModel()
        {
            AuditId = Guid.NewGuid();
        }

        [Key]
        public Guid AuditId { get; set; }

        [DisplayName("Nome do Usuário")]
        public string UserName { get; set; }

        [DisplayName("Endereço IP")]
        public string IPAddress { get; set; }

        [DisplayName("Área Acessada")]
        public string AreaAccessed { get; set; }

        [DisplayName("Data e Hora do acesso")]
        public DateTime CriadoEm { get; set; }

        [ScaffoldColumn(false)]
        public DateTime AlteradoEm { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}
