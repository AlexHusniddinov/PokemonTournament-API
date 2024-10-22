using PokemonTournament.Domain.Models.Entities;

namespace PokemonTournament.Infrastructure.Interfaces
{
    public interface IPokemonRepository
    {
        Task<List<Pokemon>> GetRandomPokemonsAsync(int count);
    }
}
