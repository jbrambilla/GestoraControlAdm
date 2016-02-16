using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Entities
{
    public class PessoaJuridica
    {
        public PessoaJuridica()
        {
            PessoaJuridicaId = Guid.NewGuid();
            EnderecoList = new List<Endereco>();
        }

        public Guid PessoaJuridicaId { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public string InscricaoMunicipal { get; set; }
        public string InscricaoEstadual { get; set; }
        public DateTime DataFundacao { get; set; }
        public virtual ICollection<Endereco> EnderecoList { get; set; }
    }
}
