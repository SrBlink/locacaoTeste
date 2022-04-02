using Locacao.Application.Dtos;
using Locacao.Domain.Entities;

namespace Locacao.Application.Addapters
{
    public static class FromReservaFinalizarRequestPatchDtoToReserva
    {
        public static Reserva Adapt(ReservaFinalizarRequestPatchDto dto)
        {
            return new Reserva
            {
                DataDevolucao = dto.DataDevolucao,
            };
        }
    }
}