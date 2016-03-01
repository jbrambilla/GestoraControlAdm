using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EGestora.GestoraControlAdm.Application.ViewModels
{
    public class AnexoViewModel
    {
        public AnexoViewModel()
        {
            AnexoId = Guid.NewGuid();
        }

        [Key]
        public Guid AnexoId { get; set; }

        [Required]
        [DisplayName("Pessoa")]
        public Guid PessoaId { get; set; }

        [Required]
        [DisplayName("Nome do Arquivo")]
        public string FileName { get; set; }

        [Required]
        [DisplayName("Tipo de Conteúdo")]
        public string ContentType { get; set; }

        [Required]
        [DisplayName("Conteúdo")]
        public byte[] Content { get; set; }

        [ScaffoldColumn(false)]
        public PessoaViewModel Pessoa { get; set; }
    }
}
