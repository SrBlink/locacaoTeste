namespace Locacao.Infrastructure.CrossCuting.DTOs
{
    public class ExceptionResponseDto
    {
        public int Codigo { get; set; }
        public string Mensagem { get; set; }

        public ExceptionResponseDto(string mensagem, int codigo = default)
        {
            Codigo = codigo;
            Mensagem = mensagem;
        }
    }
}