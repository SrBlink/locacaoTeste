namespace Locacao.Domain.Dtos
{
    public class ClienteDto
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cnh { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string ResidenciaNumero { get; set; }
        public string Cidade { get; set; }
    }
}