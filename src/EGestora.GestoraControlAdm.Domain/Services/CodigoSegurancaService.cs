using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Services
{
    public class CodigoSegurancaService : ICodigoSegurancaService
    {
        private readonly ICodigoSegurancaRepository _codigoSegurancaRepository;

        public CodigoSegurancaService(ICodigoSegurancaRepository codigoSegurancaRepository)
        {
            _codigoSegurancaRepository = codigoSegurancaRepository;
        }

        public CodigoSeguranca Add(CodigoSeguranca codigoSeguranca)
        {
            if (!codigoSeguranca.IsValid())
            {
                return codigoSeguranca;
            }

            return _codigoSegurancaRepository.Add(codigoSeguranca);
        }

        public CodigoSeguranca GetById(Guid id)
        {
            return _codigoSegurancaRepository.GetById(id);
        }

        public IEnumerable<CodigoSeguranca> GetAll()
        {
            return _codigoSegurancaRepository.GetAll();
        }

        public CodigoSeguranca Update(CodigoSeguranca codigoSeguranca)
        {
            return _codigoSegurancaRepository.Update(codigoSeguranca);
        }

        public void Remove(Guid id)
        {
            _codigoSegurancaRepository.Remove(id);
        }

        public void Dispose()
        {
            _codigoSegurancaRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
