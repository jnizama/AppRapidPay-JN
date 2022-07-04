using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RapidPay.Entities.Interfaces;
using RapidPay.Persistency.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Persistency
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRapidPayRepositories(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            
            services.AddDbContext<RapidPayContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("RapidPay")));

            //services.AddScoped<ICardRepository, CardRepository>();
            //services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;

        }
    }
}
