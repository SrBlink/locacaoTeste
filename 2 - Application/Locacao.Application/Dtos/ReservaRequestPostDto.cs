using System;
using System.Collections.Generic;
using System.Text;

namespace Locacao.Application.Dtos
{
    public class ReservaRequestPostDto
    {
        public DateTime Data { get; set; }
        public Guid ClienteId { get; set; }
        public Guid VeiculoId { get; set; }
        public DateTime? DataRetirada { get; set; }
    }
}
