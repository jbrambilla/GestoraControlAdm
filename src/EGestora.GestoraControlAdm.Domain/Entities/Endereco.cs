﻿using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGestora.GestoraControlAdm.Domain.Entities
{
    public class Endereco
    {
        public Endereco()
        {
            EnderecoId = Guid.NewGuid();
        }

        public Guid EnderecoId { get; set; }
        public Guid PessoaId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public int Ibge { get; set; }
        public bool Cobranca { get; set; }
        public bool Entrega { get; set; }
        public bool Principal { get; set; }
        public string Descricao { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public bool Erro { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
            return true;
        }

        public string EnderecoCompleto
        {
            get
            {
                return string.Format("{0}, {1} {2} - {3} | {4} - {5}", Logradouro, Numero, Complemento, Bairro, Cidade, Estado);
            }
            private set { }
        }
    }
}
