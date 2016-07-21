using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Interfaces.Service;
using EGestora.GestoraControlAdm.Domain.Validations.Pessoas;
using EGestora.GestoraControlAdm.Domain.Validations.Empresas;
using System;
using System.Linq;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IRegimeApuracaoRepository _regimeApuracaoRepository;
        private readonly IRegimeTributacaoRepository _regimeTributacaoRepository;
        private readonly INaturezaOperacaoRepository _naturezaOperacaoRepository;
        private readonly IEnquadramentoServicoRepository _enquadramentoServicoRepository;

        public EmpresaService(
            IEmpresaRepository empresaRepository, 
            IRegimeApuracaoRepository regimeApuracaoRepository,
            IRegimeTributacaoRepository regimeTributacaoRepository,
            INaturezaOperacaoRepository naturezaOperacaoRepository,
            IEnquadramentoServicoRepository enquadramentoServicoRepository)
        {
            _empresaRepository = empresaRepository;
            _regimeApuracaoRepository = regimeApuracaoRepository;
            _regimeTributacaoRepository = regimeTributacaoRepository;
            _naturezaOperacaoRepository = naturezaOperacaoRepository;
            _enquadramentoServicoRepository = enquadramentoServicoRepository;
        }

        public Empresa Add(Empresa empresa)
        {
            //if (!empresa.IsValid())
            //{
            //    return empresa;
            //}

            //empresa.ValidationResult = new EmpresaEstaAptaParaCadastroValidation(_empresaRepository).Validate(empresa);
            //if (!empresa.ValidationResult.IsValid)
            //{
            //    return empresa;
            //}

            return _empresaRepository.Add(empresa);
        }

        public Empresa GetById(Guid id)
        {
            return _empresaRepository.GetById(id);
        }

        public Empresa GetEmpresaAtiva()
        {
            return _empresaRepository.GetEmpresaAtiva();
        }

        public IEnumerable<Empresa> GetAll()
        {
            return _empresaRepository.GetAll();
        }

        public Empresa Update(Empresa empresa)
        {
            return _empresaRepository.Update(empresa);
        }

        public void Remove(Guid id)
        {
            _empresaRepository.Remove(id);
        }

        public IEnumerable<RegimeApuracao> GetAllRegimeApuracao()
        {
            return _regimeApuracaoRepository.GetAll();
        }

        public IEnumerable<NaturezaOperacao> GetAllNaturezaOperacao()
        {
            return _naturezaOperacaoRepository.GetAll();
        }

        public IEnumerable<RegimeTributacao> GetAllRegimeTributacao()
        {
            return _regimeTributacaoRepository.GetAll();
        }

        public IEnumerable<EnquadramentoServico> GetAllEnquadramentoServico()
        {
            return _enquadramentoServicoRepository.GetAll();
        }

        public void Dispose()
        {
            _empresaRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
