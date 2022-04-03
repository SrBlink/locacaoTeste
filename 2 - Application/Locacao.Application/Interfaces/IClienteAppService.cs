using Locacao.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Locacao.Application.Interfaces
{
    public interface IClienteAppService
    {
        Task<bool> CadastrarAsync(ClienteRequestPostDto cliente);
        Task<IEnumerable<ClienteResponseGetDto>> ObterAsync(string busca);
        Task<bool> AtualizarEnderecoAsync(Guid id, ClienteEnderecoRequestPatchDto endereco);
    }
}
