using Locacao.Application.Dtos;
using Locacao.Domain.Entities;
using System;

namespace Locacao.Application.Addapters
{
    public static class FromReservaRequestPostDtoToReserva
    {
        public static Reserva Adapt(ReservaRequestPostDto dto)
        {
            return new Reserva
            {
                Data = DateTime.Now,
                ClienteId = dto.ClienteId,
                VeiculoId = dto.VeiculoId,
            };
        }
    }
}