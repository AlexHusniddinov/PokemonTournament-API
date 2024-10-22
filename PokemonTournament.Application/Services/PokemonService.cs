using PokemonTournament.Application.Interfaces;
using PokemonTournament.Domain.Enums;
using PokemonTournament.Domain.Interfaces;
using PokemonTournament.Infrastructure.Interfaces;
using PokemonTournament.Domain.Models.Entities;

namespace PokemonTournament.Application.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IBattleService _battleService;

        public PokemonService(IPokemonRepository pokemonRepository, IBattleService battleService)
        {
            _pokemonRepository = pokemonRepository;
            _battleService = battleService;
        }

        public async Task<List<Pokemon>> GetRandomPokemonsAsync()
        {
            var pokemons = await _pokemonRepository.GetRandomPokemonsAsync(8);

            for (int i = 0; i < pokemons.Count; i++)
            {
                for (int j = i + 1; j < pokemons.Count; j++)
                {
                    _battleService.SimulateBattle(pokemons[i], pokemons[j]);
                }
            }

            return pokemons;
        }

        public List<Pokemon> SortPokemons(List<Pokemon> pokemons, SortBy sortBy, SortDirection sortDirection)
        {
            switch (sortBy)
            {
                case SortBy.Wins:
                    return sortDirection == SortDirection.Asc
                        ? pokemons.OrderBy(p => p.Wins).ToList()
                        : pokemons.OrderByDescending(p => p.Wins).ToList();
                case SortBy.Losses:
                    return sortDirection == SortDirection.Asc
                        ? pokemons.OrderBy(p => p.Losses).ToList()
                        : pokemons.OrderByDescending(p => p.Losses).ToList();
                case SortBy.Ties:
                    return sortDirection == SortDirection.Asc
                        ? pokemons.OrderBy(p => p.Ties).ToList()
                        : pokemons.OrderByDescending(p => p.Ties).ToList();
                case SortBy.Name:
                    return sortDirection == SortDirection.Asc
                        ? pokemons.OrderBy(p => p.Name).ToList()
                        : pokemons.OrderByDescending(p => p.Name).ToList();
                case SortBy.Id:
                    return sortDirection == SortDirection.Asc
                        ? pokemons.OrderBy(p => p.Id).ToList()
                        : pokemons.OrderByDescending(p => p.Id).ToList();
                default:
                    throw new ArgumentException("Invalid sortBy parameter");
            }
        }
    }
}
