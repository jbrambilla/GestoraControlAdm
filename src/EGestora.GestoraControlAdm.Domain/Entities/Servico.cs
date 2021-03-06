﻿using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Entities
{
    public class Servico
    {
        public Servico()
        {
            ServicoId = Guid.NewGuid();
            ClienteServicoList = new List<ClienteServico>();
        }

        public Guid ServicoId { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AlteradoEm { get; set; }

        public virtual ICollection<ClienteServico> ClienteServicoList { get; set; }
    }
}
