using Locacao.Application.Dtos;
using Locacao.Domain.Entities;

namespace Locacao.Application.Addapters
{
    public class FromEnderecoDtoToCliente
    {
        public static Cliente Adapt(EnderecoDto request)
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