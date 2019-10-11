using System;
using Microsoft.AspNetCore.Builder;

namespace TeaMonkeyFruit.Token
{
    public static class TokenExtensions
    {
        public static IApplicationBuilder UseTokenManager(
            this IApplicationBuilder builder, Action<TokenOptions> configureOptions)
        {
            var tokenOptions = new TokenOptions();
            configureOptions(tokenOptions);
            
            return builder.UseMiddleware<TokenMiddleware>(tokenOptions);
        }
    }
}