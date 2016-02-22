using EGestora.GestoraControlAdm.Domain.Entities;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Interfaces.Service
{
    public interface IRevendaService : IDisposable
    {
        Revenda Add(Revenda revenda);
        Revenda GetById(Guid id);
        Revenda GetByCnpj(string cnpj);
        Revenda GetByCpf(string cpf);
        IEnumerable<Revenda> GetAll();
        Revenda Update(Revenda revenda);
        void Remove(Guid id);

        Endereco AddEndereco(Endereco endereco);
        Endereco UpdateEndereco(Endereco endereco);
        Endereco GetEnderecoById(Guid id);
        void RemoveEndereco(Guid id);

        PessoaFisica UpdatePessoaFisica(PessoaFisica pessoaFisica);
        PessoaJuridica UpdatePessoaJuridica(PessoaJuridica pessoaJuridica);

    }
}
