using EGestora.GestoraControlAdm.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Application.Interfaces
{
    public interface IEmpresaAppService : IDisposable
    {
        EmpresaEnderecoViewModel Add(EmpresaEnderecoViewModel empresaEnderecoViewModel);
        EmpresaViewModel GetById(Guid id);
        EmpresaViewModel GetByCnpj(string cnpj);
        EmpresaViewModel GetByCpf(string cpf);
        IEnumerable<EmpresaViewModel> GetAll();
        EmpresaViewModel Update(EmpresaViewModel empresaViewModel);
        void Remove(Guid id);

        EnderecoViewModel AddEndereco(EnderecoViewModel enderecoViewModel);
        EnderecoViewModel UpdateEndereco(EnderecoViewModel enderecoViewModel);
        EnderecoViewModel GetEnderecoById(Guid id);
        void RemoveEndereco(Guid id);

        IEnumerable<CnaeViewModel> GetAllCnae();
        CnaeViewModel GetCnaeById(Guid id);
        void AddCnae(Guid id, Guid pessoaId);
        void RemoveCnae(Guid cnaeId, Guid pessoaId);
        IEnumerable<CnaeViewModel> GetAllCnaeOutPessoa(Guid id);
    }
}
