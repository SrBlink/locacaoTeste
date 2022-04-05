namespace Locacao.Application.Dtos
{
    public class VeiculoRequestPostDto : BaseRequestDto
    {
        public string Placa { get; set; }
        public string ModeloNome { get; set; }
        public string FabricanteNome { get; set; }
    }
}
