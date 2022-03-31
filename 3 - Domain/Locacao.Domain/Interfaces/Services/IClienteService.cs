using Locacao.Domain.Entities;
using System.Threading.Tasks;

namespace Locacao.Domain.Interfaces.Services
{
    public interface IClienteService
    {
        Task AddAsync(Cliente clienteDto);
    }
}