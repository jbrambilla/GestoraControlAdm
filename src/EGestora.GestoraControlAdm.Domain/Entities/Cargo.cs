using System;
using System.Collections.Generic;
namespace EGestora.GestoraControlAdm.Domain.Entities
{
    public class Cargo
    {
        public Cargo()
        {
            CargoId = Guid.NewGuid();
            FuncionarioList = new List<Funcionario>();
        }

        public Guid CargoId { get; set; }
        public string Nome { get; set; }
        public decimal Salario { get; set; }

        public virtual ICollection<Funcionario> FuncionarioList { get; set; }
    }
}
