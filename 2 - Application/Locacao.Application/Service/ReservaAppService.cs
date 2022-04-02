using Locacao.Application.Addapters;
using Locacao.Application.Dtos;
using Locacao.Application.Interfaces;
using Locacao.Application.Validations;
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
        private readonly ReservaFinalizarRequestPatchDtoValidator _reservaFinalizarRequestPatchDtoValidator;
        private readonly ReservaRequestPostDtoValidator _reservaRequestPostDtoValidator;
        private readonly ReservaRequestPatchDtoValidator _reservaRequestPatchDtoValidator;

        public ReservaAppService(
            IUnitOfWork uow,
            ReservaRequestPostDtoValidator reservaRequestPostDtoValidator,
            ReservaRequestPatchDtoValidator reservaRequestPatchDtoValidator,
            ReservaFinalizarRequestPatchDtoValidator reservaFinalizarRequestPatchDtoValidator,
            IReservaService service)
        {
            _service = service;
            _uow = uow;
            _reservaFinalizarRequestPatchDtoValidator = reservaFinalizarRequestPatchDtoValidator;
            _reservaRequestPostDtoValidator = reservaRequestPostDtoValidator;
            _reservaRequestPatchDtoValidator = reservaRequestPatchDtoValidator;
        }

        public async Task<bool> AtualizarReservaClienteAsync(Guid id, ReservaRequestPatchDto reservaData)
        {
            ValidarRequisicao(reservaData, _reservaRequestPatchDtoValidator);

            var reservaModel = FromReservaRequestPatchDtoToReserva.Adapt(reservaData);

            await _service.AtualizarReservaClienteAsync(id, reservaModel);

            return await _uow.CommitAsync();
        }

        public async Task<bool> CadastrarAsync(ReservaRequestPostDto reservaDto)
        {
            ValidarRequisicao(reservaDto, _reservaRequestPostDtoValidator);

            var reserva = FromReservaRequestPostDtoToReserva.Adapt(reservaDto);

            await _service.CadastrarAsync(reserva);

            return await _uow.CommitAsync();
        }

        public async Task<bool> FinalizarReservaAsync(Guid id, ReservaFinalizarRequestPatchDto reserva)
        {
            ValidarRequisicao(reserva, _reservaFinalizarRequestPatchDtoValidator);

            var reservaModel = FromReservaFinalizarRequestPatchDtoToReserva.Adapt(reserva);

            await _service.FinalizarReservaAsync(id, reservaModel);

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

        public async Task<IEnumerable<ReservaResponseGetDto>> ObterReservasVencidasAsync()
        {
            var reservasVencidas = await _service.ObterReservasVencidasAsync();

            return FromReservaToReservaResponseGetDto.Adapt(reservasVencidas);
        }
    }
}