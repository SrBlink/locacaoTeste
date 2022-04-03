using Locacao.Application.Dtos;
using Locacao.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Locacao.Application.Addapters
{
    public static class FromVeiculoToVeiculoResponseGetDto
    {
        public static IEnumerable<VeiculoResponseGetDto> Adapt(IEnumerable<Veiculo> entity)
        {
            var VeiculoDto = entity.Select(x => new VeiculoResponseGetDto
            {
                Id = x.Id,
                Placa = x.Placa,
                Modelo = new ModeloResponseGetDto
                {
                    Id = x.Modelo.Id,
                    Nome = x.Modelo.Nome,
                    Fabricante = new FabricanteResponseGetDto
                    {
                        Id = x.Modelo.Fabricante.Id,
                        Nome = x.Modelo.Fabricante.Nome
                    }
                },
            });

            return VeiculoDto;
        }
    }
}