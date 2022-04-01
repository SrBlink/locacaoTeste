using Locacao.Application.Dtos;
using Locacao.Domain.Entities;
using System;

namespace Locacao.Application.Addapters
{
    public static class FromVeiculoDtoToVeiculo
    {
        public static Veiculo Adapt(VeiculoGetDto dto)
        {
            return new Veiculo
            {
                Id = dto.Id ?? Guid.NewGuid(),
                Placa = dto.Placa,
                ModeloId = dto.ModeloId
            };
        }
    }
}