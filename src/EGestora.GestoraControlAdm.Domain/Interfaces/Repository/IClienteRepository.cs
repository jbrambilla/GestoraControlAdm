using EGestora.GestoraControlAdm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGestora.GestoraControlAdm.Domain.Interfaces.Repository
{
    public interface IClienteRepository : IRepositoryBase<Cliente>
    {
        Cliente GetByCnpj(string cnpj);
    }
} 
