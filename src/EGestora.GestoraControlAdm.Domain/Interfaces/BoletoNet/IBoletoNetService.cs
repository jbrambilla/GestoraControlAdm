using EGestora.GestoraControlAdm.Domain.Entities;
using System;

namespace EGestora.GestoraControlAdm.Domain.Interfaces.BoletoNet
{
    public interface IBoletoNetService
    {
        string GetHtml(Boleto boleto);
        byte[] GetBytes(Boleto boleto);
    }
}
