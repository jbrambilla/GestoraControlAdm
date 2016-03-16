using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Services
{
    public class DebitoService : IDebitoService
    {
        private readonly IDebitoRepository _debitoRepository;

        public DebitoService(IDebitoRepository debitoRepository)
        {
            _debitoRepository = debitoRepository;
        }

        public Debito Add(Debito debito)
        {
            if (!debito.IsValid())
            {
                return debito;
            }

            return _debitoRepository.Add(debito);
        }

        public Debito GetById(Guid id)
        {
            return _debitoRepository.GetById(id);
        }

        public IEnumerable<Debito> GetAll()
        {
            return _debitoRepository.GetAll();
        }

        public Debito Update(Debito debito)
        {
            return _debitoRepository.Update(debito);
        }

        public void Remove(Guid id)
        {
            _debitoRepository.Remove(id);
        }

        public void Dispose()
        {
            _debitoRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
