using System;
using System.ComponentModel.DataAnnotations;

namespace Locacao.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}