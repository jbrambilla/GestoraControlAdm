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

        public Cnae Add(Cnae cnae)
        {
            return _cnaeRepository.Add(cnae);
        }

        public Cnae GetById(Guid id)
        {
            return _cnaeRepository.GetById(id);
        }

        public IEnumerable<Cnae> GetAll()
        {
            return _cnaeRepository.GetAll();
        }

        public Cnae Update(Cnae cnae)
        {
            return _cnaeRepository.Update(cnae);
        }

        public void Remove(Guid id)
        {
            _cnaeRepository.Remove(id);
        }

        public void Dispose()
        {
            _cnaeRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
