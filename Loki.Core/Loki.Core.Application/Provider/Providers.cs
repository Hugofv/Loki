using Loki.Core.Application.Interfaces;
using Loki.Core.Application.Services;
using Loki.Core.Domain.Interfaces;
using Loki.Core.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Loki.Core.Application.Provider
{
    public static class Providers
    {
        public static void Registro(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IClienteService, ClienteService>();
            serviceCollection.AddScoped<IClienteRepository, ClienteRepository>();
        }
    }
}