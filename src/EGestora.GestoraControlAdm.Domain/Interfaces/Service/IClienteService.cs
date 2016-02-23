using EGestora.GestoraControlAdm.Domain.Entities;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Interfaces.Service
{
    public interface IClienteService : IDisposable
    {
        Cliente Add(Cliente cliente);
        Cliente GetById(Guid id);
        Cliente GetByCnpj(string cnpj);
        Cliente GetByCpf(string cpf);
        IEnumerable<Cliente> GetAll();
        Cliente Update(Cliente cliente);
        void Remove(Guid id);

        Endereco AddEndereco(Endereco endereco);
        Endereco UpdateEndereco(Endereco endereco);
        Endereco GetEnderecoById(Guid id);
        void RemoveEndereco(Guid id);

        PessoaFisica UpdatePessoaFisica(PessoaFisica pessoaFisica);
        PessoaJuridica UpdatePessoaJuridica(PessoaJuridica pessoaJuridica);

        IEnumerable<Cnae> GetAllCnae();
        Cnae GetCnaeById(Guid id);
        void AddCnae(Guid id, Guid pessoaId);
        void RemoveCnae(Guid id, Guid pessoaId);
    }
}
