using Locacao.Application.Dtos;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locacao.Application.Interfaces
{
    public interface IReservaAppService
    {
        Task<bool> CadastrarAsync(ReservaRequestPostDto reserva);
        Task<IEnumerable<ReservaResponseGetDto>> ObterRerservasClienteAsync(Guid clienteId);
        Task<IEnumerable<ReservaResponseGetDto>> ObterReservasAsync(DateTime dataInicial, DateTime dataFinal);
        Task<bool> AtualizarReservaClienteAsync(Guid id, ReservaRequestPatchDto reservaData);
        Task<bool> FinalizarReservaAsync(Guid id, ReservaFinalizarRequestPatchDto reserva);
        Task<IEnumerable<ReservaResponseGetDto>> ObterReservasVencidasAsync();
    }
}
