using Locacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locacao.Domain.Interfaces.Repositories
{
    public interface IReservaRepository
    {
        Task<IEnumerable<Reserva>> ObterReservasPendentesAsync();
        Task AddAsync(Reserva reserva);
        Task<IEnumerable<Reserva>> ObterReservasClienteAsync(Guid clienteId);
        Task<IEnumerable<Reserva>> ObterReservasAsync(DateTime dataInicial, DateTime dataFinal);
        Task<Reserva> GetByIdAsync(Guid id);
        void Update(Reserva reserva);
        Task<IEnumerable<Reserva>> ObterReservasVencidasAsync();
    }
}
