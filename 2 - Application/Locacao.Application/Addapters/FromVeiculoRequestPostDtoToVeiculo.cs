using Locacao.Application.Dtos;
using Locacao.Domain.Entities;
using System;

namespace Locacao.Application.Addapters
{
    public class FromVeiculoRequestPostDtoToVeiculo
    {
        public static Veiculo Adapt(VeiculoRequestPostDto dto)
        {
            return new Veiculo
            {
                Placa = dto.Placa,
                ModeloId = dto.ModeloId
            };
        }
    }
}