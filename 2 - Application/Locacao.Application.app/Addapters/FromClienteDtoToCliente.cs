using Locacao.Application.Dtos;
using Locacao.Domain.Entities;

namespace Locacao.Application.Addapters
{
    public static class FromClienteDtoToCliente
    {
        public static Cliente Adapt(ClienteDto request, Cliente entity)
        {
            return entity;
        }
    }
}