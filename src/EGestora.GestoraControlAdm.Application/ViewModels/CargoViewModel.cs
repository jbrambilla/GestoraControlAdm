using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace EGestora.GestoraControlAdm.Application.ViewModels
{
    public class CargoViewModel
    {
        public CargoViewModel()
        {
            CargoId = Guid.NewGuid();
            FuncionarioList = new List<FuncionarioViewModel>();
        }

        [Key]
        public Guid CargoId { get; set; }

        [Required(ErrorMessage="O campo Nome é obrigatório")]
        [MaxLength(150, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        [DisplayName("Nome do Cargo")]
        public string Nome { get; set; }

        [DataType(DataType.Currency, ErrorMessage = "Preencha um valor monetário.")]
        [DisplayName("Salário")]
        public decimal Salario { get; set; }

        [ScaffoldColumn(false)]
        public ICollection<FuncionarioViewModel> FuncionarioList { get; set; }
    }
}
