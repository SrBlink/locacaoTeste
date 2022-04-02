using Locacao.Domain.Entities;
using Locacao.Domain.Interfaces.Repositories;
using Locacao.Domain.Interfaces.Services;
using Locacao.Infrastructure.CrossCuting.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locacao.Domain.Services
{
    public class ReservaService : BaseService, IReservaService
    {
        private readonly IReservaRepository _repository;
        private readonly IClienteService _clienteService;
        private readonly IVeiculoService _veiculoService;

        public ReservaService(IReservaRepository repository, IClienteService clienteService, IVeiculoService veiculoService)
        {
            _clienteService = clienteService;
            _repository = repository;
            _veiculoService = veiculoService;
        }

        public async Task CadastrarAsync(Reserva reserva)
        {
            VerificarDatas(reserva);

            var reservasPendentes = await ObterReservasPendentesAsync();

            var reservaClientePendente = reservasPendentes.Where(x => x.ClienteId == reserva.ClienteId).Any();

            if (reservaClientePendente)
                throw new DomainException("Este cliente já possui reserva em aberto.");

            await _clienteService.VerifyExists(reserva.ClienteId);

            var veiculoReservado = reservasPendentes.Where(x => x.VeiculoId == reserva.VeiculoId).Any();

            if (veiculoReservado)
                throw new DomainException("Este veiculo já possui reserva feita.");

            await _veiculoService.VerifyExists(reserva.VeiculoId);

            await _repository.AddAsync(reserva);
        }

        public async Task<IEnumerable<Reserva>> ObterReservasAsync(DateTime dataInicial, DateTime dataFinal)
        {
            var reservas = await _repository.ObterReservasAsync(dataInicial, dataFinal);
            return reservas;
        }

        public async Task<IEnumerable<Reserva>> ObterReservasClienteAsync(Guid clienteId)
        {
            var reservas = await _repository.ObterReservasClienteAsync(clienteId);
            return reservas;
        }

        public async Task<IEnumerable<Reserva>> ObterReservasPendentesAsync()
        {
            var reservas = await _repository.ObterReservasPendentesAsync();
            return reservas;
        }

        private void VerificarDatas(Reserva reserva)
        {
            if (reserva.DataRetirada.HasValue && reserva.DataRetirada > DateTime.Now)
                throw new DomainException("Data de retirada não pode ser maior que a data atual.");
            if (reserva.DataRetirada.HasValue && reserva.DataRetirada < reserva.Data)
                throw new DomainException("Data de retirada não pode ser menor que a data da reserva.");
        }
    }
}