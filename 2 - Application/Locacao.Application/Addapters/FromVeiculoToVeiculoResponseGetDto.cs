using Locacao.Application.Dtos;
using Locacao.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Locacao.Application.Addapters
{
    public static class FromVeiculoToVeiculoResponseGetDto
    {
        public static VeiculoResponseGetDto Adapt(Veiculo entity)
        {
            return new VeiculoResponseGetDto
            {
                Id = entity.Id,
                Placa = entity.Placa,
                ModeloId = entity.ModeloId
            };
        }

        public static IEnumerable<VeiculoResponseGetDto> Adapt(IEnumerable<Veiculo> entity)
        {
            var VeiculoDto = entity.Select(x => new VeiculoResponseGetDto
            {
                Id = x.Id,
                Placa = x.Placa,
                ModeloId = x.ModeloId,
                Modelo = new ModeloResponseGetDto
                {
                    Nome = x.Modelo.Nome,
                    FabricanteId = x.Modelo.FabricanteId,
                    Fabricante = new FabricanteResponseGetDto
                    {
                        Nome = x.Modelo.Fabricante.Nome
                    }
                },
            });

            return VeiculoDto;
        }
    }
}