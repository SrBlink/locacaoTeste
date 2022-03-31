using System;
using System.Collections.Generic;
using System.Text;

namespace Locacao.Domain.Entities
{
    public  class Veiculo : BaseEntity
    {
        public string Placa { get; set; }
        public Guid ModeloId { get; set; }
        public virtual Modelo Modelo { get; set; }

        
    }
}
