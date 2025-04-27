using Fatec.Store.Framework.Core.Bases.v1.Exceptions;
using System.Net;

namespace Fatec.Store.Orders.Infrastructure.CrossCutting.v1.Exceptions
{
    public class BadRequestException(HttpStatusCode statusCode = HttpStatusCode.BadRequest, string message = "")
        : CustomException(statusCode, message)
    {
    }
}
