using Locacao.Application.Dtos;
using Locacao.Domain.Entities;
using System;

namespace Locacao.Application.Addapters
{
    public class FromVeiculoPostDtoToVeiculo
    {
        public static Veiculo Adapt(VeiculoPostDto dto)
        {
            return new Veiculo
            {
                Placa = dto.Placa,
                ModeloId = dto.ModeloId
            };
        }
    }
}