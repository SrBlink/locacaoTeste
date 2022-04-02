using Locacao.Application.Dtos;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Locacao.Application.Interfaces
{
    public interface IReservaAppService
    {
        Task<bool> CadastrarAsync(ReservaRequestPostDto reserva);
        Task<IEnumerable<ReservaResponseGetDto>> ObterRerservasClienteAsync(Guid clienteId);
        Task<IEnumerable<ReservaResponseGetDto>> ObterReservasAsync(DateTime dataInicial, DateTime dataFinal);
    }
}
