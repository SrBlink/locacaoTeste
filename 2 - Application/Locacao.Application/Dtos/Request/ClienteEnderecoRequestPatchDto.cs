namespace Locacao.Application.Dtos
{
    public class ClienteEnderecoRequestPatchDto : BaseRequestDto
    {
        public string Logradouro { get; set; }
        public string NumeroResidencia { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
    }
}
