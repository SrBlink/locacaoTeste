using Locacao.Application.Dtos;
using Locacao.Domain.Entities;

namespace Locacao.Application.Addapters
{
    public static class FromReservaRequestPostDtoToReserva
    {
        public static Reserva Adapt(ReservaRequestPostDto dto)
        {
            return new Reserva
            {
                Data = dto.Data,
                ClienteId = dto.ClienteId,
                VeiculoId = dto.VeiculoId,
                DataRetirada = dto.DataRetirada,
            };
        }
    }
}