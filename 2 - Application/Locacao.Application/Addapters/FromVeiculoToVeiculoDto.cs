using Locacao.Application.Dtos;
using Locacao.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Locacao.Application.Addapters
{
    public static class FromVeiculoToVeiculoDto
    {
        public static VeiculoGetDto Adapt(Veiculo entity)
        {
            return new VeiculoGetDto { Id = entity.Id, Placa = entity.Placa, ModeloId = entity.ModeloId };
        }

        public static IEnumerable<VeiculoGetDto> Adapt(IEnumerable<Veiculo> entity)
        {
            var VeiculoDto = entity.Select(x => new VeiculoGetDto
            {
                Id = x.Id,
                Placa = x.Placa,
                ModeloId = x.ModeloId,
                Modelo = new ModeloDto
                {
                    Nome = x.Modelo.Nome,
                    FabricanteId = x.Modelo.FabricanteId,
                    Fabricante = new FabricanteDto
                    {
                        Nome = x.Modelo.Fabricante.Nome
                    }
                },
            });

            return VeiculoDto;
        }
    }
}