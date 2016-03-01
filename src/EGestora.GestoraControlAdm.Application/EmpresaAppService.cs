﻿using AutoMapper;
using EGestora.GestoraControlAdm.Application.Interfaces;
using EGestora.GestoraControlAdm.Application.ViewModels;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Service;
using EGestora.GestoraControlAdm.Infra.CrossCutting.MvcFilters.FilePath;
using EGestora.GestoraControlAdm.Infra.CrossCutting.Utils;
using EGestora.GestoraControlAdm.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;

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

        public EmpresaEnderecoViewModel Add(EmpresaEnderecoViewModel empresaEnderecoViewModel)
        {
            var empresa = Mapper.Map<EmpresaEnderecoViewModel, Empresa>(empresaEnderecoViewModel);
            var pf = Mapper.Map<EmpresaEnderecoViewModel, PessoaFisica>(empresaEnderecoViewModel);
            var pj = Mapper.Map<EmpresaEnderecoViewModel, PessoaJuridica>(empresaEnderecoViewModel);
            var endereco = Mapper.Map<EmpresaEnderecoViewModel, Endereco>(empresaEnderecoViewModel);
            var selectedCnaeList = empresaEnderecoViewModel.SelectedCnaeList;
            var foto = empresaEnderecoViewModel.Foto;

            if (empresaEnderecoViewModel.FlagIsPessoaJuridica)
            {
                pf = null;
            }
            else
            {
                pj = null;
            }

            BeginTransaction();

            /** Adicionando PF, PJ e ENDEREÇO **/
            empresa.PessoaFisica = pf;
            empresa.PessoaJuridica = pj;
            empresa.EnderecoList.Add(endereco);
            /** FIM Adicionando PF, PJ e ENDEREÇO **/

            /** Adicionando CNAES **/
            foreach (var CnaeId in selectedCnaeList)
            {
                var cnae = _empresaService.GetCnaeById(CnaeId);
                empresa.CnaeList.Add(cnae);
            }
            /** FIM Adicionando CNAES **/

            var empresaReturn = _empresaService.Add(empresa);
            empresaEnderecoViewModel = Mapper.Map<Empresa, EmpresaEnderecoViewModel>(empresaReturn);

            if (!empresaEnderecoViewModel.ValidationResult.IsValid)
            {
                return empresaEnderecoViewModel;
            }

            if (!ImagemUtil.SalvarImagem(foto, empresaEnderecoViewModel.PessoaId, FilePathConstants.EMPRESAS_IMAGE_PATH))
            {
                // Tomada de decisão caso a imagem não seja gravada.
                empresaEnderecoViewModel.ValidationResult.Message = "Empresa salva sem foto";
            }

            Commit();
            return empresaEnderecoViewModel;
        }

        public EmpresaViewModel GetById(Guid id)
        {
            return Mapper.Map<Empresa, EmpresaViewModel>(_empresaService.GetById(id));
        }

        public EmpresaViewModel GetByCnpj(string cnpj)
        {
            return Mapper.Map<Empresa, EmpresaViewModel>(_empresaService.GetByCnpj(cnpj));
        }

        public EmpresaViewModel GetByCpf(string cpf)
        {
            return Mapper.Map<Empresa, EmpresaViewModel>(_empresaService.GetByCpf(cpf));
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

        public EnderecoViewModel AddEndereco(EnderecoViewModel enderecoViewModel)
        {
            var endereco = Mapper.Map<EnderecoViewModel, Endereco>(enderecoViewModel);

            BeginTransaction();
            _empresaService.AddEndereco(endereco);
            Commit();

            return enderecoViewModel;
        }

        public EnderecoViewModel UpdateEndereco(EnderecoViewModel enderecoViewModel)
        {
            var endereco = Mapper.Map<EnderecoViewModel, Endereco>(enderecoViewModel);

            BeginTransaction();
            _empresaService.UpdateEndereco(endereco);
            Commit();

            return enderecoViewModel;
        }

        public EnderecoViewModel GetEnderecoById(Guid id)
        {
            return Mapper.Map<Endereco, EnderecoViewModel>(_empresaService.GetEnderecoById(id));
        }

        public void RemoveEndereco(Guid id)
        {
            BeginTransaction();
            _empresaService.RemoveEndereco(id);
            Commit();
        }

        public IEnumerable<CnaeViewModel> GetAllCnae()
        {
            return Mapper.Map<IEnumerable<Cnae>, IEnumerable<CnaeViewModel>>(_empresaService.GetAllCnae());
        }

        public CnaeViewModel GetCnaeById(Guid id)
        {
            return Mapper.Map<Cnae, CnaeViewModel>(_empresaService.GetCnaeById(id));
        }

        public void AddCnae(Guid id, Guid pessoaId)
        {
            BeginTransaction();
            _empresaService.AddCnae(id, pessoaId);
            Commit();
        }

        public void RemoveCnae(Guid cnaeId, Guid pessoaId)
        {
            BeginTransaction();
            _empresaService.RemoveCnae(cnaeId, pessoaId);
            Commit();
        }

        public IEnumerable<CnaeViewModel> GetAllCnaeOutPessoa(Guid id)
        {
            return Mapper.Map<IEnumerable<Cnae>, IEnumerable<CnaeViewModel>>(_empresaService.GetAllCnaeOutPessoa(id));
        }

        public FuncionarioEnderecoViewModel AddFuncionario(FuncionarioEnderecoViewModel funcionarioEnderecoViewModel)
        {
            var funcionario = Mapper.Map<FuncionarioEnderecoViewModel, Funcionario>(funcionarioEnderecoViewModel);
            var pf = Mapper.Map<FuncionarioEnderecoViewModel, PessoaFisica>(funcionarioEnderecoViewModel);
            var pj = Mapper.Map<FuncionarioEnderecoViewModel, PessoaJuridica>(funcionarioEnderecoViewModel);
            var endereco = Mapper.Map<FuncionarioEnderecoViewModel, Endereco>(funcionarioEnderecoViewModel);
            var foto = funcionarioEnderecoViewModel.Foto;

            if (funcionarioEnderecoViewModel.FlagIsPessoaJuridica)
            {
                pf = null;
            }
            else
            {
                pj = null;
            }

            BeginTransaction();

            /** Adicionando PF, PJ e ENDEREÇO **/
            funcionario.PessoaFisica = pf;
            funcionario.PessoaJuridica = pj;
            funcionario.EnderecoList.Add(endereco);
            /** FIM Adicionando PF, PJ e ENDEREÇO **/

            var funcionarioReturn = _empresaService.AddFuncionario(funcionario);
            funcionarioEnderecoViewModel = Mapper.Map<Funcionario, FuncionarioEnderecoViewModel>(funcionarioReturn);

            if (!funcionarioEnderecoViewModel.ValidationResult.IsValid)
            {
                return funcionarioEnderecoViewModel;
            }

            if (!ImagemUtil.SalvarImagem(foto, funcionarioEnderecoViewModel.PessoaId, FilePathConstants.FUNCIONARIOS_IMAGE_PATH))
            {
                // Tomada de decisão caso a imagem não seja gravada.
                funcionarioEnderecoViewModel.ValidationResult.Message = "Funcionario salvo sem foto";
            }

            Commit();
            return funcionarioEnderecoViewModel;
        }

        public FuncionarioViewModel UpdateFuncionario(FuncionarioViewModel funcionarioViewModel)
        {
            var funcionario = Mapper.Map<FuncionarioViewModel, Funcionario>(funcionarioViewModel);

            BeginTransaction();
            var funcionarioResult = _empresaService.UpdateFuncionario(funcionario);
            funcionarioViewModel = Mapper.Map<Funcionario, FuncionarioViewModel>(funcionarioResult);
            Commit();
            return funcionarioViewModel;
        }

        public FuncionarioViewModel GetFuncionarioById(Guid id)
        {
            return Mapper.Map<Funcionario, FuncionarioViewModel>(_empresaService.GetFuncionarioById(id));
        }

        public void RemoveFuncionario(Guid id)
        {
            BeginTransaction();
            _empresaService.RemoveFuncionario(id);
            Commit();
        }

        public void Dispose()
        {
            _empresaService.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}