using EGestora.GestoraControlAdm.AntiCorruption.NfseWebService.Interfaces;
using EGestora.GestoraControlAdm.AntiCorruption.NfseWebService.Simpliss;
using EGestora.GestoraControlAdm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGestora.GestoraControlAdm.AntiCorruption.NfseWebService.Implementacao
{
    public class ItensServicoNfse : IItensServicoNfse
    {
        public tcItemServico[] GetItensServico(NotaServico notaServico)
        {
            List<ClienteServico> itens = notaServico.Cliente.ClienteServicoList.ToList();
            var itensServico = new tcItemServico[itens.Count];

            for (int i = 0; i < itens.Count; i++)
            {
                itensServico[i] = new tcItemServico();
                itensServico[i].Descricao = itens.ElementAt(i).Servico.Descricao;
                itensServico[i].Quantidade = 1;
                itensServico[i].ValorUnitario = itens.ElementAt(i).Valor;
            }

            return itensServico;
        }

    }
}
