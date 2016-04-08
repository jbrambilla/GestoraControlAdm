﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EGestora.GestoraControlAdm.Application.ViewModels
{
    class CodigoSegurancaViewModel
    {
        public CodigoSegurancaViewModel()
        {
            CodigoSegurancaId = Guid.NewGuid();
        }


        [Key]
        public Guid CodigoSegurancaId { get; set; }

        [Required]
        [DisplayName("Cliente")]
        public Guid ClienteId { get; set; }

        [Required]
        [DisplayName("Código")]
        [MaxLength(12, ErrorMessage="O Código deve ter no máximo {1} caracteres.")]
        [MinLength(12, ErrorMessage = "O Código deve ter no mínimo {1} caracteres.")]
        public string Codigo { get; set; }

        [Display(Name = "Data Atual")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataAtual { get; set; }

        [Display(Name = "Data da Trava")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataTrava { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CriadoEm { get; set; }

        [ScaffoldColumn(false)]
        public DateTime AlteradoEm { get; set; }

        [ScaffoldColumn(false)]
        public virtual ClienteViewModel Cliente { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}
