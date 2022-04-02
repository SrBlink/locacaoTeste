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

        public async Task AtualizarReservaClienteAsync(Guid id, Reserva reservaModel)
        {

            VerificarDatas(reservaModel);

            var reserva = await GetByIdAsync(id);

            if (reserva.DataDevolucao.HasValue)
                throw new DomainException("Reserva já foi finalizada e não pode ser alterada.");

            if (reservaModel.DataRetirada < reserva.Data)
                throw new DomainException("A data de retirada não pode ser menor que data em que a reserva foi feita.");

            reserva.DataRetirada = reservaModel.DataRetirada;
            reserva.DataPrevistaDevolucao = reservaModel.DataPrevistaDevolucao;

            _repository.Update(reserva);


        }

        public async Task CadastrarAsync(Reserva reserva)
        {
            VerificarDatas(reserva);

            var reservasPendentes = await ObterReservasPendentesAsync();

            var reservaClientePendente = reservasPendentes.Where(x => x.ClienteId == reserva.ClienteId).Any();

            if (reservaClientePendente)
                throw new DomainException("Este cliente já possui reserva em aberto.");

            await _clienteService.VerifyExistsAsync(reserva.ClienteId);

            var veiculoReservado = reservasPendentes.Where(x => x.VeiculoId == reserva.VeiculoId).Any();

            if (veiculoReservado)
                throw new DomainException("Este veiculo já possui reserva feita.");

            await _veiculoService.VerifyExistsAsync(reserva.VeiculoId);

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
            if (reserva.DataRetirada.HasValue && reserva.DataPrevistaDevolucao.HasValue && reserva.DataPrevistaDevolucao <= reserva.DataRetirada)
                throw new DomainException("Data prevista de devolução não pode ser menor nem igual a data de retirada");
            if (reserva.DataDevolucao.HasValue && reserva.DataDevolucao > DateTime.Now)
                throw new DomainException("Data de devolução não pode ser maior que a data atual.");
        }

        public async Task<Reserva> GetByIdAsync(Guid id) {
            var reserva = await _repository.GetByIdAsync(id);
            if (reserva == null)
                throw new DomainException("Reserva não encontrada.");
            return reserva;
        }

        public async Task FinalizarReservaAsync(Guid id, Reserva reservaModel)
        {
            VerificarDatas(reservaModel);

            var reserva = await GetByIdAsync(id);

            if (reserva.DataDevolucao.HasValue)
                throw new DomainException("Reserva já foi finalizada e não pode ser alterada.");

            if (reservaModel.DataDevolucao < reserva.DataPrevistaDevolucao)
                throw new DomainException("A data de devolução não pode ser menor que data prevista para devolução.");

            reserva.DataDevolucao = reservaModel.DataDevolucao;

            _repository.Update(reserva);

        }

        public async Task<IEnumerable<Reserva>> ObterReservasVencidasAsync()
        {
            var reservas = await _repository.ObterReservasVencidasAsync();
            return reservas;
        }
    }
}