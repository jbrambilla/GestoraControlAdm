using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Entities
{
    public class PessoaFisica
    {
        public Guid PessoaId { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Rg { get; set; }
        public string OrgaoEmissor { get; set; }
        public string Cpf { get; set; }
        public string Genero { get; set; }
        public string EstadoCivil { get; set; }
        public DateTime Nascimento { get; set; }
        public virtual Pessoa Pessoa { get; set; }

        //profissao
    }
}
