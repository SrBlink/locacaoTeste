using Locacao.Domain.Addapters;
using Locacao.Domain.Dtos;
using Locacao.Domain.Interfaces;
using Locacao.Domain.Entities.Cliente;
using Locacao.Domain.Interfaces.Services;

namespace Locacao.Domain.ApplicationService
{
    public class ClienteApplicationService : IClienteApplicationService
    {
        private readonly IClienteService _service;

        public ClienteApplicationService(IClienteService service)
        {
            _service = service;
        }

        public void Add(ClienteDto clienteDto)
        {
            _service.Add(FromClienteDtoToCliente.Adapt(clienteDto, new Cliente()));
        }

        public void Delete(ClienteDto clienteDto)
        {
            _service.Delete(FromClienteDtoToCliente.Adapt(clienteDto, new Cliente()));
        }

        public IEnumerable<ClienteDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public ClienteDto GetById(Guid id)
        {
            var cliente = _service.GetById(id);
            return FromClienteToClienteDto.Adapt(cliente, new ClienteDto());
        }

        public void Update(ClienteDto clienteDto)
        {
            _service.Update(FromClienteDtoToCliente.Adapt(clienteDto, new Cliente()));
        }
    }
}