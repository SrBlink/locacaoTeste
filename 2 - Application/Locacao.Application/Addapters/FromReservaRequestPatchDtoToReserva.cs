using Locacao.Application.Dtos;
using Locacao.Domain.Entities;

namespace Locacao.Application.Addapters
{
    public static class FromReservaRequestPatchDtoToReserva
    {
        public static Reserva Adapt(ReservaRequestPatchDto dto)
        {
            return new Reserva
            {
                DataRetirada = dto.DataRetirada,
                DataPrevistaDevolucao = dto.DataPrevistaDevolucao,
            };
        }
    }
}