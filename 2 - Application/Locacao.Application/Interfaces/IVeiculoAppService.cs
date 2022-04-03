using Locacao.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locacao.Application.Interfaces
{
    public interface IVeiculoAppService
    {
        Task<bool> CadastrarAsync(VeiculoRequestPostDto veiculo);
        Task<IEnumerable<VeiculoResponseGetDto>> ConsultarPorPlacaAsync(string busca);
        Task<IEnumerable<VeiculoResponseGetDto>> ConsultarPorModeloFabricanteAsync(string busca);
    }
}