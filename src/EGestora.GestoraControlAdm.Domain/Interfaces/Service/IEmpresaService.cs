using EGestora.GestoraControlAdm.Domain.Entities;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Interfaces.Service
{
    public interface IEmpresaService : IDisposable
    {
        Empresa Add(Empresa empresa);
        Empresa GetById(Guid id);
        Empresa GetByCnpj(string cnpj);
        Empresa GetByCpf(string cpf);
        IEnumerable<Empresa> GetAll();
        Empresa Update(Empresa empresa);
        void Remove(Guid id);

        Endereco AddEndereco(Endereco endereco);
        Endereco UpdateEndereco(Endereco endereco);
        Endereco GetEnderecoById(Guid id);
        void RemoveEndereco(Guid id);
    }
}
