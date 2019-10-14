using System.Linq;
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
            var header = httpContext.Request.Headers["Authorization"];
            var token = header.ToString().Split().LastOrDefault();
            
            tokenManager.SetAccessToken(token);
            await _next(httpContext);
        }
    }
}