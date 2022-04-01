using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Locacao.Infrastructure.DataAccess.Exceptions
{
    public  class DomainException : Exception
    {
        public HttpStatusCode Status { get; private set; }

        public IReadOnlyCollection<string> Erros { get; private set; }

        public DomainException(IReadOnlyCollection<string> erros)
        {
            Status = HttpStatusCode.BadRequest;
            Erros = erros;
        }
    }
}
