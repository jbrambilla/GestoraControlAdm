using AutoMapper;
using EGestora.GestoraControlAdm.Application.Interfaces;
using EGestora.GestoraControlAdm.Application.ViewModels;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Service;
using EGestora.GestoraControlAdm.Infra.CrossCutting.MvcFilters.FilePath;
using EGestora.GestoraControlAdm.Infra.CrossCutting.Utils;
using EGestora.GestoraControlAdm.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Web;

namespace EGestora.GestoraControlAdm.Application
{
    public class FornecedorAppService : ApplicationService, IFornecedorAppService
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedorAppService(IFornecedorService fornecedorService, IUnitOfWork _uow)
            : base(_uow)
        {
            _fornecedorService = fornecedorService;
        }

        public FornecedorEnderecoViewModel Add(FornecedorEnderecoViewModel fornecedorEnderecoViewModel)
        {
            var fornecedor = Mapper.Map<FornecedorEnderecoViewModel, Fornecedor>(fornecedorEnderecoViewModel);
            var pf = Mapper.Map<FornecedorEnderecoViewModel, PessoaFisica>(fornecedorEnderecoViewModel);
            var pj = Mapper.Map<FornecedorEnderecoViewModel, PessoaJuridica>(fornecedorEnderecoViewModel);
            var endereco = Mapper.Map<FornecedorEnderecoViewModel, Endereco>(fornecedorEnderecoViewModel);
            var contato = Mapper.Map<FornecedorEnderecoViewModel, Contato>(fornecedorEnderecoViewModel);
            var foto = fornecedorEnderecoViewModel.Foto;

            if (fornecedorEnderecoViewModel.FlagIsPessoaJuridica)
            {
                pf = null;
            }
            else
            {
                pj = null;
            }

            BeginTransaction();

            fornecedor.PessoaFisica = pf;
            fornecedor.PessoaJuridica = pj;
            fornecedor.EnderecoList.Add(endereco);
            fornecedor.ContatoList.Add(contato);

            var fornecedorReturn = _fornecedorService.Add(fornecedor);
            fornecedorEnderecoViewModel = Mapper.Map<Fornecedor, FornecedorEnderecoViewModel>(fornecedorReturn);

            if (!fornecedorEnderecoViewModel.ValidationResult.IsValid)
            {
                return fornecedorEnderecoViewModel;
            }

            if (!ImagemUtil.SalvarImagem(foto, fornecedorEnderecoViewModel.PessoaId, FilePathConstants.FORNECEDORES_IMAGE_PATH))
            {
                // Tomada de decisão caso a imagem não seja gravada.
                fornecedorEnderecoViewModel.ValidationResult.Message = "Fornecedor salvo sem foto";
            }

            Commit();
            return fornecedorEnderecoViewModel;
        }

        public FornecedorViewModel GetById(Guid id)
        {
            return Mapper.Map<Fornecedor, FornecedorViewModel>(_fornecedorService.GetById(id));
        }

        public FornecedorViewModel GetByCnpj(string cnpj)
        {
            return Mapper.Map<Fornecedor, FornecedorViewModel>(_fornecedorService.GetByCnpj(cnpj));
        }

        public FornecedorViewModel GetByCpf(string cpf)
        {
            return Mapper.Map<Fornecedor, FornecedorViewModel>(_fornecedorService.GetByCpf(cpf));
        }

        public IEnumerable<FornecedorViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Fornecedor>, IEnumerable<FornecedorViewModel>>(_fornecedorService.GetAll());
        }

        public FornecedorViewModel Update(FornecedorViewModel FornecedorViewModel)
        {
            var Fornecedor = Mapper.Map<FornecedorViewModel, Fornecedor>(FornecedorViewModel);

            BeginTransaction();
            var FornecedorResult = _fornecedorService.Update(Fornecedor);
            FornecedorViewModel = Mapper.Map<Fornecedor, FornecedorViewModel>(FornecedorResult);
            Commit();
            return FornecedorViewModel;
        }

        public void Remove(Guid id)
        {
            BeginTransaction();
            _fornecedorService.Remove(id);
            Commit();
        }

        public EnderecoViewModel AddEndereco(EnderecoViewModel enderecoViewModel)
        {
            var endereco = Mapper.Map<EnderecoViewModel, Endereco>(enderecoViewModel);

            BeginTransaction();
            _fornecedorService.AddEndereco(endereco);
            Commit();

            return enderecoViewModel;
        }

        public EnderecoViewModel UpdateEndereco(EnderecoViewModel enderecoViewModel)
        {
            var endereco = Mapper.Map<EnderecoViewModel, Endereco>(enderecoViewModel);

            BeginTransaction();
            _fornecedorService.UpdateEndereco(endereco);
            Commit();

            return enderecoViewModel;
        }

        public EnderecoViewModel GetEnderecoById(Guid id)
        {
            return Mapper.Map<Endereco, EnderecoViewModel>(_fornecedorService.GetEnderecoById(id));
        }

        public void RemoveEndereco(Guid id)
        {
            BeginTransaction();
            _fornecedorService.RemoveEndereco(id);
            Commit();
        }

        public ContatoViewModel AddContato(ContatoViewModel contatoViewModel)
        {
            var contato = Mapper.Map<ContatoViewModel, Contato>(contatoViewModel);

            BeginTransaction();
            _fornecedorService.AddContato(contato);
            Commit();

            return contatoViewModel;
        }

        public ContatoViewModel UpdateContato(ContatoViewModel contatoViewModel)
        {
            var contato = Mapper.Map<ContatoViewModel, Contato>(contatoViewModel);

            BeginTransaction();
            _fornecedorService.UpdateContato(contato);
            Commit();

            return contatoViewModel;
        }

        public ContatoViewModel GetContatoById(Guid id)
        {
            return Mapper.Map<Contato, ContatoViewModel>(_fornecedorService.GetContatoById(id));
        }

        public void RemoveContato(Guid id)
        {
            _fornecedorService.RemoveContato(id);
        }

        public void AddAnexo(Guid PessoaId, HttpPostedFileBase Arquivo)
        {
            BeginTransaction();

            var fornecedor = _fornecedorService.GetById(PessoaId);
            fornecedor.AnexoList.Add(AnexoUtil.GetEntityFromHttpPostedFileBase(Arquivo));
            _fornecedorService.Update(fornecedor);

            Commit();
        }

        public AnexoViewModel GetAnexoById(Guid id)
        {
            return Mapper.Map<Anexo, AnexoViewModel>(_fornecedorService.GetAnexoById(id));
        }

        public void RemoveAnexo(Guid id)
        {
            BeginTransaction();
            _fornecedorService.RemoveAnexo(id);
            Commit();
        }

        public void Dispose()
        {
            _fornecedorService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
