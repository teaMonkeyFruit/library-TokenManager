using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace TeaMonkeyFruit.Token
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, ITokenManager tokenManager)
        {
            tokenManager.SetAccessToken(httpContext.Request.Headers["Authorization"]);
            await _next(httpContext);
        }
    }
}