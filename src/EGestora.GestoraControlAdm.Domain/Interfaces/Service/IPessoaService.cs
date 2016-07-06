using EGestora.GestoraControlAdm.Domain.Entities;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Interfaces.Service
{
    public interface IPessoaService : IDisposable
    {
        Pessoa Add(Pessoa pessoa);
        Pessoa GetById(Guid id);
        IEnumerable<Pessoa> GetAll();
        Pessoa GetByCpf(string cpf);
        Pessoa GetByCnpj(string cnpj);
        Pessoa Update(Pessoa pessoa);
        void Remove(Guid id);

        Endereco AddEndereco(Endereco endereco);
        Endereco UpdateEndereco(Endereco endereco);
        Endereco GetEnderecoById(Guid id);
        void RemoveEndereco(Guid id);

        Contato AddContato(Contato contato);
        Contato UpdateContato(Contato contato);
        Contato GetContatoById(Guid id);
        void RemoveContato(Guid id);

        PessoaFisica UpdatePessoaFisica(PessoaFisica pessoaFisica);
        PessoaJuridica UpdatePessoaJuridica(PessoaJuridica pessoaJuridica);

        IEnumerable<TipoContato> GetAllTipoContatos();

        Anexo GetAnexoById(Guid id);
        void RemoveAnexo(Guid id);

        IEnumerable<Cnae> GetAllCnae();
        Cnae GetCnaeById(Guid id);
        void RemoveCnae(Guid id, Guid pessoaId);
        bool AddCnae(Guid id, Guid pessoaId);
        IEnumerable<Cnae> GetAllCnaeOutPessoa(Guid id);

        IEnumerable<RegimeImposto> GetAllRegimeImpostos();

        IEnumerable<Profissao> GetAllProfissoes();

        Funcionario AddFuncionario(Funcionario funcionario);
        Funcionario UpdateFuncionario(Funcionario funcionario);
        Funcionario GetFuncionarioById(Guid id);
        void RemoveFuncionario(Guid id);

        Proprietario AddProprietario(Proprietario proprietario);
        Proprietario UpdateProprietario(Proprietario proprietario);
        Proprietario GetProprietarioById(Guid id);
        void RemoveProprietario(Guid id);

        IEnumerable<PessoaFisica> GetAllPessoaFisica();
        IEnumerable<PessoaJuridica> GetAllPessoaJuridica();

        IEnumerable<Cargo> GetAllCargo();

        Endereco ObterEnderecoPeloCep(string cep);
    }
}
