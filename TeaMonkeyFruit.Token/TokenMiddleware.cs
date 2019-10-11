using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace TeaMonkeyFruit.Token
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly TokenOptions _tokenOptions;

        public TokenMiddleware(RequestDelegate next, TokenOptions options)
        {
            _next = next;
            _tokenOptions = options;
        }

        public async Task Invoke(HttpContext httpContext, ITokenManager tokenManager)
        {
            tokenManager.SetAccessToken(await httpContext.GetTokenAsync(_tokenOptions.TokenName));
            await _next(httpContext);
        }
    }
}