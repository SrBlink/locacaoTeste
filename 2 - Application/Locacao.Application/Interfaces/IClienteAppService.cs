using Locacao.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Locacao.Application.Interfaces
{
    public interface IClienteAppService
    {
        Task<bool> CadastrarAsync(ClienteDto cliente);
        Task<IEnumerable<ClienteDto>> ObterAsync(string busca);
    }
}
