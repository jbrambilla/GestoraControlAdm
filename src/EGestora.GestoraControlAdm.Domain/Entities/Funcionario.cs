using System;

namespace EGestora.GestoraControlAdm.Domain.Entities
{
    public class Funcionario : Pessoa
    {
        public Funcionario()
            : base()
        {

        }

        public Guid EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}
