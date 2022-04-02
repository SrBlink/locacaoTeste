using Locacao.Application.Dtos;
using Locacao.Domain.Entities;

namespace Locacao.Application.Addapters
{
    public class FromClienteEnderecoRequestPatchDtoToCliente
    {
        public static Cliente Adapt(ClienteEnderecoRequestPatchDto request)
        {
            return new Cliente
            {
                Logradouro = request.Logradouro,
                NumeroResidencia = request.NumeroResidencia,
                Bairro = request.Bairro,
                Cidade = request.Cidade,
            };
        }
    }
}