using EGestora.GestoraControlAdm.Domain.Entities;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Interfaces.Service
{
    public interface IEmpresaService : IDisposable
    {
        Empresa Add(Empresa empresa);
        Empresa GetById(Guid id);
        Empresa GetByCnpj(string cnpj);
        Empresa GetByCpf(string cpf);
        IEnumerable<Empresa> GetAll();
        Empresa Update(Empresa empresa);
        void Remove(Guid id);

        Endereco AddEndereco(Endereco endereco);
        Endereco UpdateEndereco(Endereco endereco);
        Endereco GetEnderecoById(Guid id);
        void RemoveEndereco(Guid id);

        PessoaFisica UpdatePessoaFisica(PessoaFisica pessoaFisica);
        PessoaJuridica UpdatePessoaJuridica(PessoaJuridica pessoaJuridica);

        IEnumerable<Cnae> GetAllCnae();
        Cnae GetCnaeById(Guid id);
        void RemoveCnae(Guid id, Guid pessoaId);
        void AddCnae(Guid id, Guid pessoaId);
        IEnumerable<Cnae> GetAllCnaeOutPessoa(Guid id);

        Funcionario AddFuncionario(Funcionario funcionario);
        Funcionario UpdateFuncionario(Funcionario funcionario);
        Funcionario GetFuncionarioById(Guid id);
        void RemoveFuncionario(Guid id);

        IEnumerable<RegimeApuracao> GetAllRegimeApuracao();

        IEnumerable<NaturezaOperacao> GetAllNaturezaOperacao();

        IEnumerable<RegimeTributacao> GetAllRegimeTributacao();

        IEnumerable<EnquadramentoServico> GetAllEnquadramentoServico();

        Anexo GetAnexoById(Guid id);
        void RemoveAnexo(Guid id);
    }
}
