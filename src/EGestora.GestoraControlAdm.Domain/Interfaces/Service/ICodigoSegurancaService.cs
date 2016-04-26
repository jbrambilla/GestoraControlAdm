using EGestora.GestoraControlAdm.Domain.Entities;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Interfaces.Service
{
    public interface ICodigoSegurancaService : IDisposable
    {
        CodigoSeguranca Add(CodigoSeguranca codigoSeguranca);
        CodigoSeguranca GetById(Guid id);
        IEnumerable<CodigoSeguranca> GetAll();
        CodigoSeguranca Update(CodigoSeguranca codigoSeguranca);
        void Remove(Guid id);

        IEnumerable<Cliente> GetAllClientes();

        CodigoSeguranca EnviarEmail(CodigoSeguranca codigoSeguranca);
    }
}
