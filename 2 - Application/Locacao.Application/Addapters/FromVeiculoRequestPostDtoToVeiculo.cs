using Locacao.Application.Dtos;
using Locacao.Domain.Entities;

namespace Locacao.Application.Addapters
{
    public class FromVeiculoRequestPostDtoToVeiculo
    {
        public static Veiculo Adapt(VeiculoRequestPostDto dto)
        {
            return new Veiculo
            {
                Placa = dto.Placa,
                Modelo = new Modelo
                {
                    Nome = dto.ModeloNome.ToUpper(),
                    Fabricante = new Fabricante
                    {
                        Nome = dto.FabricanteNome.ToUpper()
                    }
                }
            };
        }
    }
}