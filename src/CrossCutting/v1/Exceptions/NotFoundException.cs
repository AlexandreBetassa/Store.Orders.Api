using Fatec.Store.Framework.Core.Bases.v1.Exceptions;
using System.Net;

namespace Fatec.Store.Orders.Infrastructure.CrossCutting.v1.Exceptions
{
    public class NotFoundException : CustomException
    {
        public NotFoundException(HttpStatusCode statusCode = HttpStatusCode.NotFound, string message = "")
            : base(statusCode, message)
        {
        }
    }
}
