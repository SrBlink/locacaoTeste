using Locacao.Application.Addapters;
using Locacao.Application.Dtos;
using Locacao.Application.Interfaces;
using Locacao.Application.Validations;
using Locacao.Domain.Interfaces.Services;
using Locacao.Domain.Interfaces.UoW;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locacao.Application.Service
{
    public class ClienteAppService : BaseAppService, IClienteAppService
    {
        private readonly IClienteService _service;

        private readonly IUnitOfWork _uow;
        private readonly ClienteRequestPostDtoValidator _clienteRequestPostDtoValidator;
        private readonly ClienteEnderecoRequestPatchDtoValidator _clienteEnderecoRequestPatchDtoValidator;

        public ClienteAppService(
                IUnitOfWork uow,
                IClienteService service,
                ClienteEnderecoRequestPatchDtoValidator clienteEnderecoRequestPatchDtoValidator,
                ClienteRequestPostDtoValidator clienteRequestPostDtoValidator
            )
        {
            _uow = uow;
            _service = service;
            _clienteRequestPostDtoValidator = clienteRequestPostDtoValidator;
            _clienteEnderecoRequestPatchDtoValidator = clienteEnderecoRequestPatchDtoValidator;
        }

        public async Task<bool> AtualizarEnderecoAsync(Guid id, ClienteEnderecoRequestPatchDto endereco)
        {
            ValidarRequisicao(endereco, _clienteEnderecoRequestPatchDtoValidator);

            var cliente = FromClienteEnderecoRequestPatchDtoToCliente.Adapt(endereco);

            await _service.AtualizarEnderecoAsync(id, cliente);

            return await _uow.CommitAsync();
        }

        public async Task<bool> CadastrarAsync(ClienteRequestPostDto clienteDto)
        {
            ValidarRequisicao(clienteDto, _clienteRequestPostDtoValidator);

            var cliente = FromClienteRequestPostDtoToCliente.Adapt(clienteDto);

            await _service.AddAsync(cliente);

            return await _uow.CommitAsync();
        }

        public async Task<IEnumerable<ClienteResponseGetDto>> ObterAsync(string busca)
        {
            var cliente = await _service.ObterPorCpfNomeAsync(busca);

            return FromClienteToClienteResponseGetDto.Adapt(cliente);
        }
    }
}