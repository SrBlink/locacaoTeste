using System;
using System.Net;

namespace Locacao.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public HttpStatusCode Status { get; private set; }
        public string Erro { get; private set; }

        public DomainException(string erro)
        {
            Status = HttpStatusCode.BadRequest;
            Erro = erro;
        }
    }
}