using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Entities
{
    public class PessoaFisica
    {
        public PessoaFisica()
        {
            PessoaFisicaId = Guid.NewGuid();
            EnderecoList = new List<Endereco>();
        }

        public Guid PessoaFisicaId { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Genero { get; set; }
        public DateTime Nascimento { get; set; }
        public ICollection<Endereco> EnderecoList { get; set; }
    }
}
