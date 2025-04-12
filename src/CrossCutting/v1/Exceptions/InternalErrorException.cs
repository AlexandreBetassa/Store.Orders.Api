using Fatec.Store.Framework.Core.Bases.v1.Exceptions;
using System.Net;

namespace Fatec.Store.Orders.Infrastructure.CrossCutting.v1.Exceptions
{
    public class InternalErrorException(
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError,
        string message = "Ocorreu um erro interno. Contate o administrador")
        : CustomException(statusCode, message)
    {
    }
}
