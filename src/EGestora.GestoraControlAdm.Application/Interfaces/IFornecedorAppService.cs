using EGestora.GestoraControlAdm.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Web;

namespace EGestora.GestoraControlAdm.Application.Interfaces
{
    public interface IFornecedorAppService : IDisposable
    {
        FornecedorEnderecoViewModel Add(FornecedorEnderecoViewModel fornecedorEnderecoViewModel);
        FornecedorViewModel GetById(Guid id);
        FornecedorViewModel GetByCnpj(string cnpj);
        FornecedorViewModel GetByCpf(string cpf);
        IEnumerable<FornecedorViewModel> GetAll();
        FornecedorViewModel Update(FornecedorViewModel fornecedorViewModel);
        void Remove(Guid id);

        EnderecoViewModel AddEndereco(EnderecoViewModel enderecoViewModel);
        EnderecoViewModel UpdateEndereco(EnderecoViewModel enderecoViewModel);
        EnderecoViewModel GetEnderecoById(Guid id);
        void RemoveEndereco(Guid id);

        void AddAnexo(Guid PessoaId, HttpPostedFileBase Arquivo);
        AnexoViewModel GetAnexoById(Guid id);
        void RemoveAnexo(Guid id);
    }
}
