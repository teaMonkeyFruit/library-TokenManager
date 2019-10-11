using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

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

        public static IServiceCollection AddTokenManager(this IServiceCollection services)
        {
            services.AddScoped<ITokenManager, TokenManager>();

            return services;
        }
    }
}