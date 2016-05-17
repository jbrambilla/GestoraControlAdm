using System;

namespace EGestora.GestoraControlAdm.Domain.Entities
{
    public class Funcionario
    {
        public Funcionario()
        {
            FuncionarioId = Guid.NewGuid();
        }
        public Guid FuncionarioId { get; set; }
        public Guid PessoaId { get; set; }
        public Guid CargoId { get; set; }
        public Guid PessoaJuridicaId { get; set; }
        public string Descricao { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public virtual Cargo Cargo { get; set; }
        public virtual PessoaJuridica PessoaJuridica { get; set; }
    }
}

