using EGestora.GestoraControlAdm.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Web;

namespace EGestora.GestoraControlAdm.Application.Interfaces
{
    public interface IPessoaAppService : IDisposable 
    {
        PessoaEnderecoViewModel Add(PessoaEnderecoViewModel pessoaEnderecoViewModel);
        PessoaViewModel GetById(Guid id);
        IEnumerable<PessoaViewModel> GetAll();
        PessoaViewModel Update(PessoaViewModel pessoaViewModel);
        void Remove(Guid id);

        EnderecoViewModel AddEndereco(EnderecoViewModel enderecoViewModel);
        EnderecoViewModel UpdateEndereco(EnderecoViewModel enderecoViewModel);
        EnderecoViewModel GetEnderecoById(Guid id);
        void RemoveEndereco(Guid id);

        ContatoViewModel AddContato(ContatoViewModel contatoViewModel);
        ContatoViewModel UpdateContato(ContatoViewModel contatoViewModel);
        ContatoViewModel GetContatoById(Guid id);
        void RemoveContato(Guid id);

        IEnumerable<TipoContatoViewModel> GetAllTipoContatos();

        void AddAnexo(Guid PessoaId, HttpPostedFileBase Arquivo);
        AnexoViewModel GetAnexoById(Guid id);
        void RemoveAnexo(Guid id);
    }
}
