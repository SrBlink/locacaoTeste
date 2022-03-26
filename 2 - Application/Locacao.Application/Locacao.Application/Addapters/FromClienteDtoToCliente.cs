using Locacao.Domain.Dtos;
using Locacao.Domain.Entities.Cliente;


namespace Locacao.Domain.Addapters
{
    public static class FromClienteDtoToCliente
    {
        public static Cliente Adapt(ClienteDto request, Cliente entity) {

            return entity;
        }
    }
}
