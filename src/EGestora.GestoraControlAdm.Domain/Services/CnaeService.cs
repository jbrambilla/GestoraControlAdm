using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Services
{
    public class CnaeService : ICnaeService
    {
        private readonly ICnaeRepository _cnaeRepository;

        public CnaeService(ICnaeRepository cnaeRepository)
        {
            _cnaeRepository = cnaeRepository;
        }

        Cnae Add(Cnae cnae)
        {
            return _cnaeRepository.Add(cnae);
        }

        Cnae GetById(Guid id)
        {
            return _cnaeRepository.GetById(id);
        }

        IEnumerable<Cnae> GetAll()
        {
            return _cnaeRepository.GetAll();
        }

        IEnumerable<Cnae> GetByPessoaId(Guid id)
        {
            return _cnaeRepository.GetByPessoaId(id);
        }

        Cnae Update(Cnae cnae)
        {
            return _cnaeRepository.Update(cnae);
        }

        void Remove(Guid id)
        {
            _cnaeRepository.Remove(id);
        }

        void System.IDisposable.Dispose()
        {
            _cnaeRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
