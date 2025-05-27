using Microsoft.AspNetCore.Http;

namespace Fatec.Store.Orders.Application.v1.Shared.Extensions
{
    public static class HttpContextExtensions
    {
        public static string GetUserName(this IHttpContextAccessor context) =>
            context?.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type.Equals("name"))?.Value ?? string.Empty;

        public static string GetUserId(this IHttpContextAccessor context) =>
             context?.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type.Equals("id"))?.Value ?? string.Empty;
    }
}
