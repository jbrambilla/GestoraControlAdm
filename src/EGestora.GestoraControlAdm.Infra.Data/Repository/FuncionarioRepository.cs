﻿using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EGestora.GestoraControlAdm.Infra.Data.Repository
{
    public class FuncionarioRepository : RepositoryBase<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(EGestoraContext context)
            : base(context)
        {

        }
    }
}
