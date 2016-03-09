using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Services
{
    public class LoteFaturamentoService : ILoteFaturamentoService
    {
        private readonly ILoteFaturamentoRepository _loteFaturamentoRepository;

        public LoteFaturamentoService(ILoteFaturamentoRepository loteFaturamentoRepository)
        {
            _loteFaturamentoRepository = loteFaturamentoRepository;
        }

        public LoteFaturamento Add(LoteFaturamento loteFaturamento)
        {
            if (!loteFaturamento.IsValid())
            {
                return loteFaturamento;
            }

            return _loteFaturamentoRepository.Add(loteFaturamento);
        }

        public LoteFaturamento GetById(Guid id)
        {
            return _loteFaturamentoRepository.GetById(id);
        }

        public IEnumerable<LoteFaturamento> GetAll()
        {
            return _loteFaturamentoRepository.GetAll();
        }

        public LoteFaturamento Update(LoteFaturamento loteFaturamento)
        {
            return _loteFaturamentoRepository.Update(loteFaturamento);
        }

        public void Remove(Guid id)
        {
            _loteFaturamentoRepository.Remove(id);
        }

        public void Dispose()
        {
            _loteFaturamentoRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
