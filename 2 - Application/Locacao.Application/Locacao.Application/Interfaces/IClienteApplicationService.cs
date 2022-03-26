using Locacao.Domain.Dtos;

namespace Locacao.Domain.Interfaces
{
    public interface IClienteApplicationService
    {
        void Add(ClienteDto clienteDto);

        void Update(ClienteDto clienteDto);

        void Delete(ClienteDto clienteDto);

        IEnumerable<ClienteDto> GetAll();

        ClienteDto GetById(Guid id);
    }
}