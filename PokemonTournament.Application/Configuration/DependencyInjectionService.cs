using Microsoft.Extensions.DependencyInjection;
using PokemonTournament.Application.Interfaces;
using PokemonTournament.Application.Services;
using PokemonTournament.Domain.Interfaces;
using PokemonTournament.Domain.Services;
using PokemonTournament.Infrastructure.Interfaces;
using PokemonTournament.Infrastructure.Repositories;

namespace PokemonTournament.Application.Configuration
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {

            //add services
            services.AddScoped<IPokemonService, PokemonService>();
            services.AddScoped<IBattleService, BattleService>();

            //add repositories
            services.AddScoped<IPokemonRepository, PokemonRepository>();

            return services;
        }
    }
}
