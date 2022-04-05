using System;
using System.Collections.Generic;
using System.Net;

namespace Locacao.Infrastructure.CrossCuting.Exceptions
{
    public class ValidationException : Exception
    {
        public HttpStatusCode Status { get; private set; }
        public IReadOnlyCollection<string> Erros { get; private set; }

        public ValidationException(IReadOnlyCollection<string> erros)
        {
            Status = HttpStatusCode.BadRequest;
            Erros = erros;
        }

    }
}
