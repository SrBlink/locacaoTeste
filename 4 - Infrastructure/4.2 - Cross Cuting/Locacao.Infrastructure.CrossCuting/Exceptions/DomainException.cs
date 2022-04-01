using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Locacao.Infrastructure.CrossCuting.Exceptions
{
    public  class DomainException : Exception
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
