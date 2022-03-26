using Locacao.Domain.Dtos;
using Locacao.Domain.Entities.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locacao.Domain.Addapters
{
    public static class FromClienteToClienteDto
    {
        public static ClienteDto Adapt(Cliente entity, ClienteDto response) {
            
            return response;
        }
    }
}
