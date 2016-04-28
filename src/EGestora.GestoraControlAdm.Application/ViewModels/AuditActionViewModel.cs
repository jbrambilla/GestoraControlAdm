using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EGestora.GestoraControlAdm.Application.ViewModels
{
    public class AuditActionViewModel
    {
        public AuditActionViewModel()
        {
            AuditActionId = Guid.NewGuid();
        }

        [Key]
        [DisplayName("Ação")]
        public Guid AuditActionId { get; set; }

        [Required(ErrorMessage = "A Action deve pertencer a um controller.")]
        [DisplayName("Controller")]
        public Guid AuditControllerId { get; set; }

        [Required(ErrorMessage = "O Nome da Ação é obrigatório.")]
        [MaxLength(150, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        [DisplayName("Ação")]
        public string ActionName { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CriadoEm { get; set; }

        [ScaffoldColumn(false)]
        public DateTime AlteradoEm { get; set; }

        [ScaffoldColumn(false)]
        public AuditControllerViewModel AuditController { get; set; }
    }
}
