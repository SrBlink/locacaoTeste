using Locacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Locacao.Domain.Interfaces.Services
{
    public interface IReservaService
    {
        Task CadastrarAsync(Reserva reserva);
        Task<IEnumerable<Reserva>> ObterReservasClienteAsync(Guid clienteId);
        Task<IEnumerable<Reserva>> ObterReservasAsync(DateTime dataInicial, DateTime dataFinal);
        Task AtualizarReservaClienteAsync(Guid id, Reserva reservaModel);
        Task FinalizarReservaAsync(Guid id, Reserva reservaModel);
        Task<IEnumerable<Reserva>> ObterReservasVencidasAsync();
    }
}
