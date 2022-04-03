using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Locacao.Infrastructure.CrossCuting.Exceptions
{
    public  class DomainValidationException : Exception
    {
        public HttpStatusCode Status { get; private set; }
        public IReadOnlyCollection<string> Erros { get; private set; }

        public DomainValidationException(IReadOnlyCollection<string> erros)
        {
            Status = HttpStatusCode.BadRequest;
            Erros = erros;
        }
        
    }
}
