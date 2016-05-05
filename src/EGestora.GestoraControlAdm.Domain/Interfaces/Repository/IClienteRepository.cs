using EGestora.GestoraControlAdm.Domain.Entities;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Interfaces.Repository
{
    public interface IClienteRepository : IPessoaComplexaRepository<Cliente>
    {
        IEnumerable<Cliente> GetAllSemNota();
        IEnumerable<Cliente> GetAllComNota();
    }
} 
