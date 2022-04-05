using System;

namespace Locacao.Domain.Entities
{
    public class Modelo : BaseEntity
    {
        public Guid FabricanteId { get; set; }
        public string Nome { get; set; }
        public virtual Fabricante Fabricante { get; set; }
    }
}