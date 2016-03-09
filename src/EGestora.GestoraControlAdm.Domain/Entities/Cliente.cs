﻿using DomainValidation.Validation;
using System;
using System.Linq;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Entities
{
    public class Cliente : Pessoa
    {
        public Cliente()
            : base()
        {
            CnaeList = new List<Cnae>();
            ClienteServicoList = new List<ClienteServico>();
            NotaServicoList = new List<NotaServico>();
            LoteFaturamentoList = new List<LoteFaturamento>();
        }

        public Guid? RevendaId { get; set; }
        public Guid RegimeApuracaoId { get; set; }
        public bool ComNota { get; set; }
        public DateTime VencimentoBoleto { get; set; }
        public decimal Repasse { get; set; }
        public bool RepassePercentual { get; set; }
        public virtual Revenda Revenda { get; set; }
        public virtual RegimeApuracao RegimeApuracao { get; set; }
        public virtual ICollection<Cnae> CnaeList { get; set; }
        public virtual ICollection<ClienteServico> ClienteServicoList { get; set; }
        public virtual ICollection<NotaServico> NotaServicoList { get; set; }
        public virtual ICollection<LoteFaturamento> LoteFaturamentoList { get; set; }

        public decimal ValorTotalServicos 
        { 
            get 
            {
                var valor = 0M;
                ClienteServicoList.ToList().ForEach(clienteServico => valor += clienteServico.Valor);
                return valor;
            } 
        }
    }
}
