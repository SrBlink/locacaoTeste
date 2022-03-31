using Locacao.Application.Dtos;
using Locacao.Domain.Entities;

namespace Locacao.Application.Addapters
{
    public static class FromClienteToClienteDto
    {
        public static ClienteDto Adapt(Cliente entity, ClienteDto response)
        {
            return response;
        }
    }
}