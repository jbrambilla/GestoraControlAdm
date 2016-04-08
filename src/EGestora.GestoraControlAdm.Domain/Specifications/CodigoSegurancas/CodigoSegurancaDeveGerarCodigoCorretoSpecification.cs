﻿using DomainValidation.Interfaces.Specification;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using System;

namespace EGestora.GestoraControlAdm.Domain.Specifications.CodigoSegurancas
{
    public class CodigoSegurancaDeveGerarCodigoCorretoSpecification : ISpecification<CodigoSeguranca>
    {
        private readonly ICodigoSegurancaRepository _codigoSegurancaRepository;

        public CodigoSegurancaDeveGerarCodigoCorretoSpecification(ICodigoSegurancaRepository codigoSegurancaRepository)
        {
            _codigoSegurancaRepository = codigoSegurancaRepository;
        }

        public bool IsSatisfiedBy(CodigoSeguranca codigoSeguranca)
        {
            var codigoSegurancaTeste = new CodigoSeguranca()
            {
                DataAtual = codigoSeguranca.DataAtual,
                ClienteId = codigoSeguranca.ClienteId,
                Cliente = codigoSeguranca.Cliente,
                Codigo = "111111111111"
            };

            codigoSegurancaTeste.DataTrava = codigoSeguranca.DataTrava;

            _codigoSegurancaRepository.GerarCodigo(codigoSegurancaTeste);

            return codigoSeguranca.Codigo.Length == 12 && codigoSeguranca.Codigo == codigoSegurancaTeste.Codigo;
        }
    }
}