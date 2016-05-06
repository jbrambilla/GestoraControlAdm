using EGestora.GestoraControlAdm.Domain.Entities;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Interfaces.Repository
{
    public interface IEnderecoRepository : IRepositoryBase<Endereco>
    {
        IEnumerable<Endereco> GetAllByPessoaId(Guid id);
    }
}
