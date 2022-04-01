using Locacao.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locacao.Application.Interfaces
{
    public interface IVeiculoAppService
    {
        Task<bool> CadastrarAsync(VeiculoPostDto veiculo);
        Task<IEnumerable<VeiculoGetDto>> ConsultarPorPlacaAsync(string busca);
        Task<IEnumerable<VeiculoGetDto>> ConsultarPorModeloFabricante(string busca);
    }
}