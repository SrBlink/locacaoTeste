using Locacao.Application.Addapters;
using Locacao.Application.Dtos;
using Locacao.Application.Interfaces;
using Locacao.Domain.Interfaces.Services;
using Locacao.Domain.Interfaces.UoW;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locacao.Application.Service
{
    public class ReservaAppService : BaseAppService, IReservaAppService
    {
        private readonly IReservaService _service;
        private readonly IUnitOfWork _uow;

        public ReservaAppService(
            IUnitOfWork uow,
            IReservaService service)
        {
            _service = service;
            _uow = uow;
        }

        public async Task<bool> CadastrarAsync(ReservaRequestPostDto reservaDto)
        {
            var reserva = FromReservaRequestPostDtoToReserva.Adapt(reservaDto);

            await _service.CadastrarAsync(reserva);

            return await _uow.CommitAsync();
        }

        public async Task<IEnumerable<ReservaResponseGetDto>> ObterRerservasClienteAsync(Guid clienteId)
        {
            var clienteReservas = await _service.ObterReservasClienteAsync(clienteId);

            return FromReservaToReservaResponseGetDto.Adapt(clienteReservas);
        }

        public async Task<IEnumerable<ReservaResponseGetDto>> ObterReservasAsync(DateTime dataInicial, DateTime dataFinal)
        {
            var reservas = await _service.ObterReservasAsync(dataInicial, dataFinal);

            return FromReservaToReservaResponseGetDto.Adapt(reservas);
        }
    }
}