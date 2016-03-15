using EGestora.GestoraControlAdm.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Web;

namespace EGestora.GestoraControlAdm.Application.Interfaces
{
    public interface IRevendaAppService : IDisposable
    {
        RevendaEnderecoViewModel Add(RevendaEnderecoViewModel revendaEnderecoViewModel);
        RevendaViewModel GetById(Guid id);
        RevendaViewModel GetByCnpj(string cnpj);
        RevendaViewModel GetByCpf(string cpf);
        IEnumerable<RevendaViewModel> GetAll();
        RevendaViewModel Update(RevendaViewModel revendaViewModel);
        void Remove(Guid id);

        EnderecoViewModel AddEndereco(EnderecoViewModel enderecoViewModel);
        EnderecoViewModel UpdateEndereco(EnderecoViewModel enderecoViewModel);
        EnderecoViewModel GetEnderecoById(Guid id);
        void RemoveEndereco(Guid id);

        ContatoViewModel AddContato(ContatoViewModel contatoViewModel);
        ContatoViewModel UpdateContato(ContatoViewModel contatoViewModel);
        ContatoViewModel GetContatoById(Guid id);
        void RemoveContato(Guid id);

        void AddAnexo(Guid PessoaId, HttpPostedFileBase Arquivo);
        AnexoViewModel GetAnexoById(Guid id);
        void RemoveAnexo(Guid id);
    }
}
