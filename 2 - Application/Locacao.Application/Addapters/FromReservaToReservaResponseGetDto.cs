using Locacao.Application.Dtos;
using Locacao.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Locacao.Application.Addapters
{
    public static class FromReservaToReservaResponseGetDto
    {
        public static ReservaResponseGetDto Adapt(Reserva entity)
        {
            return new ReservaResponseGetDto
            {
                Id = entity.Id,
                Data = entity.Data,
                ClienteId = entity.ClienteId,
                VeiculoId = entity.VeiculoId,
                DataRetirada = entity.DataRetirada,
                DataPrevistaDevolucao = entity.DataPrevistaDevolucao,
                DataDevolucao = entity.DataDevolucao
            };
        }

        public static IEnumerable<ReservaResponseGetDto> Adapt(IEnumerable<Reserva> entity)
        {
            return entity.Select(x => new ReservaResponseGetDto
            {
                Id = x.Id,
                Data = x.Data,
                ClienteId = x.ClienteId,
                VeiculoId = x.VeiculoId,
                DataRetirada = x.DataRetirada,
                DataPrevistaDevolucao = x.DataPrevistaDevolucao,
                DataDevolucao = x.DataDevolucao,
                ClienteNome = x.Cliente.Nome,
                VeiculoPlaca = x.Veiculo.Placa
            });
        }
    }
}