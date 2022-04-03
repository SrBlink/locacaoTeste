using System;
using System.Collections.Generic;

namespace Locacao.Infrastructure.CrossCuting.DTOs
{
    public class ExceptionResponseDto
    {
        public DateTime Data { get; set; }

        public ICollection<ExceptionErroResponseDto> Erros { get; set; }


        public class ExceptionErroResponseDto
        {
            public string Mensagem { get; set; }

            public ExceptionErroResponseDto(string mensagem) => Mensagem = mensagem;
        }

        public ExceptionResponseDto(string mensagem)
        {
            Data = DateTime.Now;
            Erros = new List<ExceptionErroResponseDto>
            {
                new ExceptionErroResponseDto(mensagem)
            };
        }

        public ExceptionResponseDto(IReadOnlyCollection<string> mensagens)
        {
            Data = DateTime.Now;
            Erros = new List<ExceptionErroResponseDto>();

            foreach (var mensagem in mensagens)
                Erros.Add(new ExceptionErroResponseDto(mensagem));
        }
    }
}