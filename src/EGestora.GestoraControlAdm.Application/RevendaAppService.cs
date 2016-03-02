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
    public class RevendaAppService : ApplicationService, IRevendaAppService
    {
        private readonly IRevendaService _revendaService;

        public RevendaAppService(IRevendaService revendaService, IUnitOfWork _uow)
            : base(_uow)
        {
            _revendaService = revendaService;
        }

        public RevendaEnderecoViewModel Add(RevendaEnderecoViewModel revendaEnderecoViewModel)
        {
            var revenda = Mapper.Map<RevendaEnderecoViewModel, Revenda>(revendaEnderecoViewModel);
            var pf = Mapper.Map<RevendaEnderecoViewModel, PessoaFisica>(revendaEnderecoViewModel);
            var pj = Mapper.Map<RevendaEnderecoViewModel, PessoaJuridica>(revendaEnderecoViewModel);
            var endereco = Mapper.Map<RevendaEnderecoViewModel, Endereco>(revendaEnderecoViewModel);
            var foto = revendaEnderecoViewModel.Foto;

            if (revendaEnderecoViewModel.FlagIsPessoaJuridica)
            {
                pf = null;
            }
            else
            {
                pj = null;
            }

            BeginTransaction();

            revenda.PessoaFisica = pf;
            revenda.PessoaJuridica = pj;
            revenda.EnderecoList.Add(endereco);

            var revendaReturn = _revendaService.Add(revenda);
            revendaEnderecoViewModel = Mapper.Map<Revenda, RevendaEnderecoViewModel>(revendaReturn);

            if (!revendaEnderecoViewModel.ValidationResult.IsValid)
            {
                return revendaEnderecoViewModel;
            }

            if (!ImagemUtil.SalvarImagem(foto, revendaEnderecoViewModel.PessoaId, FilePathConstants.REVENDAS_IMAGE_PATH))
            {
                // Tomada de decisão caso a imagem não seja gravada.
                revendaEnderecoViewModel.ValidationResult.Message = "Revenda salvo sem foto";
            }

            Commit();
            return revendaEnderecoViewModel;
        }

        public RevendaViewModel GetById(Guid id)
        {
            return Mapper.Map<Revenda, RevendaViewModel>(_revendaService.GetById(id));
        }

        public RevendaViewModel GetByCnpj(string cnpj)
        {
            return Mapper.Map<Revenda, RevendaViewModel>(_revendaService.GetByCnpj(cnpj));
        }

        public RevendaViewModel GetByCpf(string cpf)
        {
            return Mapper.Map<Revenda, RevendaViewModel>(_revendaService.GetByCpf(cpf));
        }

        public IEnumerable<RevendaViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Revenda>, IEnumerable<RevendaViewModel>>(_revendaService.GetAll());
        }

        public RevendaViewModel Update(RevendaViewModel RevendaViewModel)
        {
            var Revenda = Mapper.Map<RevendaViewModel, Revenda>(RevendaViewModel);

            BeginTransaction();
            var RevendaResult = _revendaService.Update(Revenda);
            RevendaViewModel = Mapper.Map<Revenda, RevendaViewModel>(RevendaResult);
            Commit();
            return RevendaViewModel;
        }

        public void Remove(Guid id)
        {
            BeginTransaction();
            _revendaService.Remove(id);
            Commit();
        }

        public EnderecoViewModel AddEndereco(EnderecoViewModel enderecoViewModel)
        {
            var endereco = Mapper.Map<EnderecoViewModel, Endereco>(enderecoViewModel);

            BeginTransaction();
            _revendaService.AddEndereco(endereco);
            Commit();

            return enderecoViewModel;
        }

        public EnderecoViewModel UpdateEndereco(EnderecoViewModel enderecoViewModel)
        {
            var endereco = Mapper.Map<EnderecoViewModel, Endereco>(enderecoViewModel);

            BeginTransaction();
            _revendaService.UpdateEndereco(endereco);
            Commit();

            return enderecoViewModel;
        }

        public EnderecoViewModel GetEnderecoById(Guid id)
        {
            return Mapper.Map<Endereco, EnderecoViewModel>(_revendaService.GetEnderecoById(id));
        }

        public void RemoveEndereco(Guid id)
        {
            BeginTransaction();
            _revendaService.RemoveEndereco(id);
            Commit();
        }

        public void AddAnexo(Guid PessoaId, HttpPostedFileBase Arquivo)
        {
            BeginTransaction();

            var revenda = _revendaService.GetById(PessoaId);
            revenda.AnexoList.Add(AnexoUtil.GetEntityFromHttpPostedFileBase(Arquivo));
            _revendaService.Update(revenda);

            Commit();
        }

        public AnexoViewModel GetAnexoById(Guid id)
        {
            return Mapper.Map<Anexo, AnexoViewModel>(_revendaService.GetAnexoById(id));
        }

        public void RemoveAnexo(Guid id)
        {
            BeginTransaction();
            _revendaService.RemoveAnexo(id);
            Commit();
        }

        public void Dispose()
        {
            _revendaService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
