using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace TeaMonkeyFruit.Token
{
    public static class TokenExtensions
    {
        public static IApplicationBuilder UseTokenManager(
            this IApplicationBuilder builder)
        {       
            return builder.UseMiddleware<TokenMiddleware>();
        }

        public static IServiceCollection AddTokenManager(this IServiceCollection services)
        {
            services.AddScoped<ITokenManager, TokenManager>();

            return services;
        }
    }
}