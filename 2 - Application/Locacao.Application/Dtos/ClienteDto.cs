using System;

namespace Locacao.Application.Dtos
{
    public class ClienteDto : EnderecoDto
    {
        public Guid? Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cnh { get; set; }
        
    }
}