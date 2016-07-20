using DomainValidation.Validation;
using System;
using System.Linq;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Entities
{
    public class Cliente
    {
        public Cliente()
        {
            ClienteId = Guid.NewGuid();
            ClienteServicoList = new List<ClienteServico>();
            NotaServicoList = new List<NotaServico>();
            LoteFaturamentoList = new List<LoteFaturamento>();
            CodigoSegurancaList = new List<CodigoSeguranca>();
            DebitoList = new List<Debito>();
        }

        public Guid ClienteId { get; set; }
        public Guid PessoaId { get; set; }
        public Guid? RevendaId { get; set; }
        public Guid RegimeApuracaoId { get; set; }
        public bool ComNota { get; set; }
        public DateTime VencimentoBoleto { get; set; }
        public decimal Repasse { get; set; }
        public bool RepassePercentual { get; set; }

        public virtual Pessoa Pessoa { get; set; }
        public virtual Revenda Revenda { get; set; }
        public virtual RegimeApuracao RegimeApuracao { get; set; }
        public virtual ICollection<ClienteServico> ClienteServicoList { get; set; }
        public virtual ICollection<NotaServico> NotaServicoList { get; set; }
        public virtual ICollection<LoteFaturamento> LoteFaturamentoList { get; set; }
        public virtual ICollection<Debito> DebitoList { get; set; }
        public virtual ICollection<CodigoSeguranca> CodigoSegurancaList { get; set; }

        public decimal ValorTotalServicos 
        { 
            get 
            {
                var valor = 0M;
                ClienteServicoList.ToList().ForEach(clienteServico => valor += clienteServico.Valor);
                return valor;
            } 
        }

        public string DiscriminacaoServicos 
        { 
            get 
            {
                var discriminacao = "";
                ClienteServicoList.ToList().ForEach(clienteServico => discriminacao += clienteServico.Servico.Descricao + ", ");
                return discriminacao.Length > 0 ? discriminacao.Remove(discriminacao.Length - 2, 2) : "";
            }
        }

        public Debito ObterUltimoDebitoAtivo()
        {
            return DebitoList.OrderByDescending(c => c.CriadoEm).FirstOrDefault();
        }
    }
}
