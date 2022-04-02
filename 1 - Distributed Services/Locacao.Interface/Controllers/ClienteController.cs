using Locacao.Application.Dtos;
using Locacao.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Locacao.Interface.Controllers
{
    [Produces("application/json")]
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
        /// Cadastrar Cliente
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Cadastrar(ClienteRequestPostDto cliente) {
            var result = await _clienteAppService.CadastrarAsync(cliente);
            return Ok(result);
        }

        /// <summary>
        /// Obter cliente por nome ou cpf
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Obter([FromQuery] string busca) {

            var result = await _clienteAppService.ObterAsync(busca);
            return Ok(result);
        }

        /// <summary>
        /// Atualizar endereco do cliente
        /// </summary>
        /// <returns></returns>
        [HttpPatch("{id}/endereco")]
        public async Task<IActionResult> AtualizarEndereco([FromRoute] Guid id , [FromBody] ClienteEnderecoRequestPatchDto endereco)
        {

            var result = await _clienteAppService.AtualizarEnderecoAsync(id , endereco);
            return Ok(result);
        }

    }
}
