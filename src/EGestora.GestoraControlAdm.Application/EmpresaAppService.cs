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
    public class EmpresaAppService : ApplicationService, IEmpresaAppService
    {
        private readonly IEmpresaService _empresaService;

        public EmpresaAppService(IEmpresaService empresaService, IUnitOfWork uow)
            : base(uow)
        {
            _empresaService = empresaService;
        }

        public EmpresaViewModel Add(EmpresaViewModel empresaViewModel)
        {
            var empresa = Mapper.Map<EmpresaViewModel, Empresa>(empresaViewModel);

            BeginTransaction();

            var empresaReturn = _empresaService.Add(empresa);
            empresaViewModel = Mapper.Map<Empresa, EmpresaViewModel>(empresaReturn);

            //if (!empresaEnderecoViewModel.ValidationResult.IsValid)
            //{
            //    return empresaEnderecoViewModel;
            //}

            //if (!ImagemUtil.SalvarImagem(foto, empresaEnderecoViewModel.PessoaId, FilePathConstants.EMPRESAS_IMAGE_PATH))
            //{
            //    // Tomada de decisão caso a imagem não seja gravada.
            //    empresaEnderecoViewModel.ValidationResult.Message = "Empresa salva sem foto";
            //}

            Commit();
            return empresaViewModel;
        }

        public EmpresaViewModel GetById(Guid id)
        {
            return Mapper.Map<Empresa, EmpresaViewModel>(_empresaService.GetById(id));
        }

        public EmpresaViewModel GetEmpresaAtiva()
        {
            return Mapper.Map<Empresa, EmpresaViewModel>(_empresaService.GetEmpresaAtiva());
        }

        public IEnumerable<EmpresaViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Empresa>, IEnumerable<EmpresaViewModel>>(_empresaService.GetAll());
        }

        public EmpresaViewModel Update(EmpresaViewModel empresaViewModel)
        {
            var empresa = Mapper.Map<EmpresaViewModel, Empresa>(empresaViewModel);

            BeginTransaction();
            var empresaResult = _empresaService.Update(empresa);
            empresaViewModel = Mapper.Map<Empresa, EmpresaViewModel>(empresaResult);
            Commit();
            return empresaViewModel;
        }

        public void Remove(Guid id)
        {
            BeginTransaction();
            _empresaService.Remove(id);
            Commit();
        }

        public IEnumerable<RegimeApuracaoViewModel> GetAllRegimeApuracao()
        {
            return Mapper.Map<IEnumerable<RegimeApuracao>, IEnumerable<RegimeApuracaoViewModel>>(_empresaService.GetAllRegimeApuracao());
        }

        public IEnumerable<NaturezaOperacaoViewModel> GetAllNaturezaOperacao()
        {
            return Mapper.Map<IEnumerable<NaturezaOperacao>, IEnumerable<NaturezaOperacaoViewModel>>(_empresaService.GetAllNaturezaOperacao());
        }

        public IEnumerable<RegimeTributacaoViewModel> GetAllRegimeTributacao()
        {
            return Mapper.Map<IEnumerable<RegimeTributacao>, IEnumerable<RegimeTributacaoViewModel>>(_empresaService.GetAllRegimeTributacao());
        }

        public IEnumerable<EnquadramentoServicoViewModel> GetAllEnquadramentoServico()
        {
            return Mapper.Map<IEnumerable<EnquadramentoServico>, IEnumerable<EnquadramentoServicoViewModel>>(_empresaService.GetAllEnquadramentoServico());
        }

        public void Dispose()
        {
            _empresaService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
