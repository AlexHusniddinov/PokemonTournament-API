using PokemonTournament.Domain.Models.Entities;

namespace PokemonTournament.Domain.Interfaces
{
    public interface IBattleService
    {
        void SimulateBattle(Pokemon pokemon1, Pokemon pokemon2);
    }
}
