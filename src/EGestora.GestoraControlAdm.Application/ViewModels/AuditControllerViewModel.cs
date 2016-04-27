using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EGestora.GestoraControlAdm.Application.ViewModels
{
    public class AuditControllerViewModel
    {
        public AuditControllerViewModel()

        {
            AuditControllerId = Guid.NewGuid();
            AuditActionList = new List<AuditActionViewModel>();
            ActionNameList = new List<string>();
        }

        [Key]
        public Guid AuditControllerId { get; set; }

        [Required(ErrorMessage = "O Nome do Controller é obrigatório.")]
        [DisplayName("Controller")]
        public string ControllerName { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CriadoEm { get; set; }

        [ScaffoldColumn(false)]
        public DateTime AlteradoEm { get; set; }

        [ScaffoldColumn(false)]
        public ICollection<AuditActionViewModel> AuditActionList { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        [ScaffoldColumn(false)]
        public IEnumerable<string> ActionNameList { get; set; }
    }
}
