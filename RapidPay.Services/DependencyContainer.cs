using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RapidPay.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Services
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRapidPayServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            
            services.AddTransient<ICardManagementService, CardManagementService>();
            // Encrypt Service
            services.AddTransient<IEncryptService, EncryptService>();
            // Auth Service
            services.AddTransient<IAuthService, AuthService>();

            int.TryParse(configuration.GetSection("UFE:MinValue").Value, out int minValue);
            int.TryParse(configuration.GetSection("UFE:MaxValue").Value, out int maxValue);
            int.TryParse(configuration.GetSection("UFE:Decimals").Value, out int decimals);
            int.TryParse(configuration.GetSection("UFE:IntervalInMinutes").Value, out int intervalInMinutes);


            services.AddSingleton<IUniversalFeeExchangeService>(
                provider => new UniversalFeeExchangeService(minValue, maxValue, decimals, intervalInMinutes));

            string secretKey = configuration.GetSection("Authentication:SecretKey").Value;
            string issuer = configuration.GetSection("Authentication:Issuer").Value;
            string audience = configuration.GetSection("Authentication:Audience").Value;

            if (!int.TryParse(configuration.GetSection("Authentication:Duration").Value, out int duration))
            {
                duration = 30;
            }

            services.AddTransient<ITokenService>(
                token => new TokenService(secretKey, issuer, audience, duration));

            return services;

        }
    }
}
