using PokemonTournament.Domain.Enums;
using PokemonTournament.Domain.Models.Entities;

namespace PokemonTournament.Application.Interfaces
{
    public interface IPokemonService
    {
        Task<List<Pokemon>> GetRandomPokemonsAsync();
        List<Pokemon> SortPokemons(List<Pokemon> pokemons, SortBy sortBy, SortDirection sortDirection);
    }

}
