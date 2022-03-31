using Locacao.Application.Addapters;
using Locacao.Application.Dtos;
using Locacao.Application.Interfaces;
using Locacao.Domain.Entities;
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

        public ClienteAppService(IUnitOfWork uow, IClienteService service)
        {
            _uow = uow;
            _service = service;
        }

        public async Task<bool> AtualizarEndereco(Guid id, EnderecoDto endereco)
        {
            var cliente = FromEnderecoDtoToCliente.Adapt(endereco);

            await _service.UpdateEndereco(id, cliente);

            return await _uow.CommitAsync();
        }

        public async Task<bool> CadastrarAsync(ClienteDto clienteDto)
        {
            //validator

            var cliente = FromClienteDtoToCliente.Adapt(clienteDto);

            await _service.AddAsync(cliente);

            return await _uow.CommitAsync();
        }

        public async Task<IEnumerable<ClienteDto>> ObterAsync(string busca)
        {
            var cliente = await _service.ObterPorCpfNome(busca);

            return FromClienteToClienteDto.Adapt(cliente);
        }
    }
}