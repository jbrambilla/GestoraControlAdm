using EGestora.GestoraControlAdm.Domain.Entities;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Interfaces.Service
{
    public interface IFornecedorService : IDisposable
    {
        Fornecedor Add(Fornecedor fornecedor);
        Fornecedor GetById(Guid id);
        Fornecedor GetByCnpj(string cnpj);
        Fornecedor GetByCpf(string cpf);
        IEnumerable<Fornecedor> GetAll();
        Fornecedor Update(Fornecedor fornecedor);
        void Remove(Guid id);

        Endereco AddEndereco(Endereco endereco);
        Endereco UpdateEndereco(Endereco endereco);
        Endereco GetEnderecoById(Guid id);
        void RemoveEndereco(Guid id);

        Contato AddContato(Contato contato);
        Contato UpdateContato(Contato contato);
        Contato GetContatoById(Guid id);
        void RemoveContato(Guid id);

        PessoaFisica UpdatePessoaFisica(PessoaFisica pessoaFisica);
        PessoaJuridica UpdatePessoaJuridica(PessoaJuridica pessoaJuridica);

        Anexo GetAnexoById(Guid id);
        void RemoveAnexo(Guid id);
    }
}
