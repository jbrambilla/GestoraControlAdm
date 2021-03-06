﻿using EGestora.GestoraControlAdm.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Web;

namespace EGestora.GestoraControlAdm.Application.Interfaces
{
    public interface IPessoaAppService : IDisposable 
    {
        PessoaEnderecoViewModel Add(PessoaEnderecoViewModel pessoaEnderecoViewModel);
        PessoaViewModel Add(PessoaViewModel pessoaViewModel);
        PessoaViewModel GetById(Guid id);
        PessoaViewModel GetByCpf(string cpf);
        PessoaViewModel GetByCnpj(string cnpj);
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

        IEnumerable<CnaeViewModel> GetAllCnae();
        CnaeViewModel GetCnaeById(Guid id);
        bool AddCnae(Guid id, Guid pessoaId);
        void RemoveCnae(Guid cnaeId, Guid pessoaId);
        IEnumerable<CnaeViewModel> GetAllCnaeOutPessoa(Guid id);

        IEnumerable<RegimeImpostoViewModel> GetAllRegimeImpostos();

        PessoaFisicaViewModel UpdatePessoaFisica(PessoaFisicaViewModel pessoaFisicaViewModel);
        PessoaJuridicaViewModel UpdatePessoaJuridica(PessoaJuridicaViewModel pessoaJuridicaViewModel);

        IEnumerable<ProfissaoViewModel> GetAllProfissoes();

        FuncionarioViewModel AddFuncionario(FuncionarioViewModel funcionarioViewModel);
        FuncionarioViewModel UpdateFuncionario(FuncionarioViewModel funcionarioViewModel);
        FuncionarioViewModel GetFuncionarioById(Guid id);
        void RemoveFuncionario(Guid id);

        ProprietarioViewModel AddProprietario(ProprietarioViewModel proprietarioViewModel);
        ProprietarioViewModel UpdateProprietario(ProprietarioViewModel proprietarioViewModel);
        ProprietarioViewModel GetProprietarioById(Guid id);
        void RemoveProprietario(Guid id);

        IEnumerable<PessoaFisicaViewModel> GetAllPessoaFisica();
        IEnumerable<PessoaJuridicaViewModel> GetAllPessoaJuridica();
        IEnumerable<CargoViewModel> GetAllCargo();

        EnderecoViewModel ObterEnderecoPeloCep(string cep);
    }
}
