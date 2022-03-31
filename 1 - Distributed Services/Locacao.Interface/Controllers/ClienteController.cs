using Locacao.Application.Dtos;
using Locacao.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Locacao.Interface.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteAppService _clienteAppService;

        public ClienteController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        /// <summary>
        /// Cadastrar Cliente.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Cadastrar(ClienteDto cliente) {
            var result = await _clienteAppService.CadastrarAsync(cliente);
            return Ok(result);
        }

    }
}
